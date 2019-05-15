using Bank;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoBank.Interfaces
{
    public interface IMoralityPlayersBank
    {
        Contract GetContract();
        decimal ConvertToDecimal(BigInteger value);
        Task<string> MintCollection(MintCollectionArguments args);
        Task<double> GetCollectionItemPrice(string collectionName);
        Task<string> BuyItemFromCollection(string collectionName, double value);
    }
}
