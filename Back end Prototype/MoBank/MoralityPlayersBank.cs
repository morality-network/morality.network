using Nethereum.StandardTokenEIP20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Web3.Accounts.Managed;
using System.Net;
using Bank;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3.Accounts;
using Nethereum.ABI.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using RateIt.Utilities;
using RateIt.Common.Models;
using MoBank.Interfaces;
using static MoBank.MoralityPlayersContractFunctions;

namespace MoBank
{
    public class MoralityPlayersBank : StandardTokenService, IMoralityPlayersBank
    {
        private string _infura;
        private string _contractAddress;
        private string _abi;
        private string _ownerAddress;

        public MoralityPlayersBank(Web3 web3, string contractAddress, string infura, string abi, string ownerAddress) : base(web3, contractAddress)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _infura = infura;
            _contractAddress = contractAddress;
            _abi = abi;
            _ownerAddress = ownerAddress;
        }

        public Nethereum.Contracts.Contract GetContract()
        {
            return Web3.Eth.GetContract(_abi, _contractAddress);
        }

        public async Task<string> MintCollection(MintCollectionArguments args)
        {
            if (args == null) return null;
            var pricePerToken = Web3.Convert.ToWei(args.TokenPrice);
            var createCollection = GetContract().GetFunction("createCollection");
            var gas = await createCollection.EstimateGasAsync(_ownerAddress, null, null, args.Name,
                args.Description, args.CollectionName, args.CollectionOwner, args.TotalToMint,
                     pricePerToken);
            var trans = await createCollection.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null,
                args.Name, args.Description, args.CollectionName, args.CollectionOwner, args.TotalToMint,
                     pricePerToken);
            return trans;
        }

        public async Task<double> GetCollectionItemPrice(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName)) return 0;
            var contract = GetContract();
            var priceFunction = contract.GetFunction("collectionPricePerUnit");
            var price = await priceFunction.CallAsync<BigInteger>(collectionName);
            return (double)ConvertToDecimal(price);
        }

        public async Task<string> BuyItemFromCollection(string collectionName, double value)
        {
            if (string.IsNullOrEmpty(collectionName)) return null;
            var priceToPay = Web3.Convert.ToWei(value);
            var buyItemFromCollection = GetContract().GetFunction("buyToken");
            var gas = await buyItemFromCollection.EstimateGasAsync(_ownerAddress, null, 
                new HexBigInteger(priceToPay), collectionName);
            var trans = await buyItemFromCollection.SendTransactionAsync(_ownerAddress, gas, 
                new HexBigInteger(priceToPay), collectionName);
            return trans;
        }

        public decimal ConvertToDecimal(BigInteger value)
        {
            if(value != null)
                return Web3.Convert.FromWei(value);
            return 0;
        }
    }
}
