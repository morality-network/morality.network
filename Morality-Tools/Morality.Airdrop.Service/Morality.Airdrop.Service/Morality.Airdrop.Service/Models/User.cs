using System;
using System.Collections.Generic;
using System.Text;

namespace Morality.Airdrop.Service.Models
{
    public class User
    {
        public int Id { get; set; }
        public double MoHeldByReserve { get; set; }
        public double BoundedMo { get; set; }
        public double Probability { get; set; }
        public double CumulitiveProbability { get; set; }
    }
}
