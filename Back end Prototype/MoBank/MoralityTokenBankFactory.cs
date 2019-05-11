using MoBank;
using MoBank.Interfaces;
using Nethereum.StandardTokenEIP20;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class MoralityTokenBankFactory
    {
        public static IMoralityTokenBank GetMoralityTokenBank(MoralityTokenSettings settings)
        {
            var client = Web3Factory.GetWeb3(settings.InfuraAddress, settings.AdminPass);
            return new MoralityTokenBank(client, settings.ContractAddress, settings.InfuraAddress, settings.Abi, settings.AdminAddress);
        }

        public static IMoralityTokenBank GetMoralityTokenBank(MoralityTokenSettings settings, string userPassword)
        {
            var client = Web3Factory.GetWeb3(settings.InfuraAddress, settings.AdminPass);
            return new MoralityTokenBank(client, settings.ContractAddress, settings.InfuraAddress, settings.Abi, settings.AdminAddress);
        }

        public static StandardTokenService GetMoralityStandardTokenBank(MoralityTokenSettings settings)
        {
            var web3 = new Web3(settings.InfuraAddress);
            var standardTokenService = new StandardTokenService(web3, settings.ContractAddress);
            return standardTokenService;
        }
    }
}
