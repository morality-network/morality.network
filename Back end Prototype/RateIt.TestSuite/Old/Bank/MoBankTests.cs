using BlockChainTest;
using Moq;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NUnit.Framework;
using RateIt.Utilities;
using RateItRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Bank
{
    public class MoBankTests
    {
        private MoService _moService;
        private Web3 _web3;
        private Function _transfer;

        [SetUp]
        public void SetUp()
        {
            _web3 = new Web3(new Account(ConfigReader.GetInstance().MoralityAdminPK), ConfigReader.GetInstance().Infura);
            _moService = new MoService(_web3, "0x97e8dbc4bab20a825edc72df441bde3102508605");
 
        }

        [Test]
        public void GetGasDoesntReturnNull()
        {
            var gas = _moService.GetGas<HexBigInteger>(_moService.GetTransferFunctions(), ConfigReader.GetInstance().MoralityAdminAddress, ConfigReader.GetInstance().MoralityAdminAddress, new HexBigInteger(100)).Result;
            Assert.IsNotNull(gas);
            Assert.IsTrue(gas.Value > new BigInteger(0));
        }
    }
}
