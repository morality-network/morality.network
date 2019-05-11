using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Web3Factory
    {
        public static Web3 GetWeb3(string infuraAddress, string adminPass)
        {
            var pk = new Account(adminPass);
            var web3 = new Web3(pk, infuraAddress);
            return web3;
        }
    }
}
