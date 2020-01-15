using Morality.Airdrop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Morality.Airdrop.Service
{
    public class AirdropService
    {
        public double MinX { get; private set; }
        public double MaxX { get; private set; }
        public double MaxAmountToSend { get; private set; }
        private Random _randomGenerator;
        public Dictionary<int, int> Distribution { get; private set; }

        public AirdropService(double minMoBound, double maxMoBound, double maxAmount)
        {
            MinX = minMoBound;
            MaxX = maxMoBound;
            MaxAmountToSend = maxAmount;
            Distribution = new Dictionary<int, int>();
            _randomGenerator = new Random();
        }

        public IEnumerable<AirDrop> GetAirdrops(List<User> users, int numberOfGiveaways)
        {
            Distribution = new Dictionary<int, int>();
            var totalMo = CalculateTotalMoHeld(users);
            users = GenerateProbabilities(users, totalMo);
            for (int i = 0; i < numberOfGiveaways; i++)
            {
                var randomNumber = _randomGenerator.Next(0, (int)((double)users.Count * 10.0));
                double nRandomNumber = randomNumber > 0.0 ? (((double)randomNumber) / ((double)users.Count * 10.0)) : 0.0;
                var winnerId = IdentifyWinner(users, nRandomNumber);
                // Map the outcomes
                if (Distribution.ContainsKey(winnerId))
                    Distribution[winnerId]++;
                else Distribution[winnerId] = 1;
                // Return the winners
                yield return new AirDrop()
                {
                    Id = winnerId,
                    Amount = _randomGenerator.Next(0, (int)MaxAmountToSend)
                };
            }
        }

        public int IdentifyWinner(List<User> users, double value)
        {
            foreach (var user in users)
            {
                if (user.CumulitiveProbability >= value)
                    return user.Id;
            }
            return users.Last()?.Id ?? -1;
        }

        public List<User> GenerateProbabilities(List<User> users, double totalMo)
        {
            var cumuluitiveProbability = 0.0;
            foreach (var user in users)
            {
                user.Probability = user.BoundedMo / totalMo;
                cumuluitiveProbability += user.Probability;
                user.CumulitiveProbability = cumuluitiveProbability;
            }
            return users;
        }

        public double CalculateTotalMoHeld(List<User> users)
        {
            return users.Sum(x =>
            {
                x.BoundedMo = BoundValue(x.MoHeldByReserve);
                return x.BoundedMo;
            });
        }

        public double BoundValue(double value)
        {
            if(value == 0)
                return value;
            else if (value <= MinX)
                return MinX;
            else if (value >= MaxX)
                return MaxX;
            else return value;
        }
    }
}
