using Microsoft.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public class ConfigReader
    {
        private static ConfigReader _reader { get; set; }
        private static KeyVaultClient _kv;

        public string Infura => GetSecret("Infura");
        public string DefaultConnectionPW => GetSecret("DefaultConnectionPW");
        public string MoralityAdminAddress => GetSecret("MoralityAdminAddress");
        public string MoralityAdminPK => GetSecret("MoralityAdminPK");
        public string MoralityAdminPassword => GetSecret("MoralityAdminPassword");
        public string RIEntitiesPassword => GetSecret("RIEntitiesPassword");
        public string DetectorUsername => GetSecret("DetectorUsername");
        public string DetectorPassword => GetSecret("DetectorPassword");
        public string RedisPass => GetSecret("RedisPassword");
        public string RedisHost => GetSecret("RedisHost");

        private ConfigReader()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            _kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        }

        public string GetSecret(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        public async Task<string> GetSecretFromKeyVault(string name)
        {
            var secret = await _kv.GetSecretAsync("https://rateit-kv.vault.azure.net", name);
            return secret.Value;
        }

        public static ConfigReader GetInstance()
        {
            if (_reader == null) _reader = new ConfigReader();
            return _reader;
        }

    }
     
}

