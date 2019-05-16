using Bank;
using MoBank.Interfaces;
using NUnit.Framework;
using RateIt.Common.Models;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Token
{
    public class MoralityPlayersTests
    {
        private MoralityTokenSettings _adminTokenSettings;
        private MoralityTokenSettings _userTokenSettings;
        private IMoralityPlayersBank _moralityPlayersBank;

        [SetUp]
        public void Setup()
        {
            _adminTokenSettings = new MoralityTokenSettings()
            {
                PlayersAbi = "[{'constant':true,'inputs':[],'name':'getAllCollectionNamesCount','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_interfaceID','type':'bytes4'}],'name':'supportsInterface','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionTotal','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'allPlayers','outputs':[{'name':'id','type':'uint256'},{'name':'name','type':'string'},{'name':'description','type':'string'},{'name':'collectionName','type':'string'},{'name':'itemNumber','type':'uint256'},{'name':'totalInExistance','type':'uint256'},{'name':'tokenPrice','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'name','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_tokenId','type':'uint256'}],'name':'getApproved','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_approved','type':'address'},{'name':'_tokenId','type':'uint256'}],'name':'approve','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_name','type':'string'},{'name':'_description','type':'string'},{'name':'_collectionName','type':'string'},{'name':'_collectionOwner','type':'address'},{'name':'_totalToMint','type':'uint256'},{'name':'_tokenPrice','type':'uint256'}],'name':'createCollection','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionNamesUsed','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'allCollectionNames','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'totalWeiUsed','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_from','type':'address'},{'name':'_to','type':'address'},{'name':'_tokenId','type':'uint256'}],'name':'transferFrom','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'inLockdown','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_collectionName','type':'string'}],'name':'tokensLeft','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_from','type':'address'},{'name':'_to','type':'address'},{'name':'_tokenId','type':'uint256'}],'name':'safeTransferFrom','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'moralityWallet','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_collectionName','type':'string'},{'name':'_n','type':'uint256'}],'name':'removeNTokensFromCollection','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionTotalRaised','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'}],'name':'getAllTokenIdsForAddress','outputs':[{'name':'ids','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_collectionName','type':'string'}],'name':'stopAnyMoreOfCollectionBeingSold','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_from','type':'address'},{'name':'_to','type':'address'},{'name':'_tokenId','type':'uint256'},{'name':'_data','type':'bytes'}],'name':'safeTransferFromWithData','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'_tokenId','type':'uint256'}],'name':'ownerOf','outputs':[{'name':'_owner','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'newWallet','type':'address'}],'name':'updateMoralityWallet','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_collectionName','type':'string'}],'name':'buyToken','outputs':[],'payable':true,'stateMutability':'payable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionItemDescription','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'}],'name':'balanceOf','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'state','type':'bool'}],'name':'updateLockdownState','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionRunningCount','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'acceptOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'id','type':'uint256'}],'name':'getTokenById','outputs':[{'name':'','type':'uint256'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'uint256'},{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'totalTokens','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'owner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'symbol','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionPricePerUnit','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_operator','type':'address'},{'name':'_approved','type':'bool'}],'name':'setApprovalForAll','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_collectionName','type':'string'},{'name':'newTokenPrice','type':'uint256'}],'name':'updateCollectionItemPrice','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'string'}],'name':'collectionItemName','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'},{'name':'_operator','type':'address'}],'name':'isApprovedForAll','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'deprecateContract','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_newOwner','type':'address'}],'name':'transferOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'inputs':[{'name':'_moralityWallet','type':'address'},{'name':'_tokenName','type':'string'},{'name':'_tokenSymbol','type':'string'}],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'updatedBy','type':'address'},{'indexed':true,'name':'oldWallet','type':'address'},{'indexed':true,'name':'newWallet','type':'address'}],'name':'UpdatedWallet','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'collectionOwner','type':'address'},{'indexed':true,'name':'name','type':'string'},{'indexed':true,'name':'collectionName','type':'string'},{'indexed':false,'name':'totalToMint','type':'uint256'},{'indexed':false,'name':'pricePerUnit','type':'uint256'}],'name':'CollectionCreated','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'collectionName','type':'string'},{'indexed':false,'name':'oldPrice','type':'uint256'},{'indexed':false,'name':'newTokenPrice','type':'uint256'}],'name':'UpdateTokenPrice','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'},{'indexed':true,'name':'_tokenId','type':'uint256'}],'name':'Transfer','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_owner','type':'address'},{'indexed':true,'name':'_approved','type':'address'},{'indexed':true,'name':'_tokenId','type':'uint256'}],'name':'Approval','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_owner','type':'address'},{'indexed':true,'name':'_operator','type':'address'},{'indexed':false,'name':'_approved','type':'bool'}],'name':'ApprovalForAll','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'}],'name':'OwnershipTransferred','type':'event'}]",
                AdminAddress = "0x5c9D8ed10c263F1bB02404145E7cE49CEC0D87F0",
                AdminPass = ConfigurationManager.AppSettings["AdminPK"],
                PlayersAddress = "0x49a21B4204B3365E7f083651E45e48D064bcD5A6",
                InfuraAddress = ConfigurationManager.AppSettings["RinkebyInfura"]
            };
            _userTokenSettings = new MoralityTokenSettings()
            {
                PlayersAbi = "",
                AdminAddress = "0x5E1970A7Caa3E95f314d70936E6384927594eB1e",
                AdminPass = ConfigurationManager.AppSettings["UserPK"],
                PlayersAddress = "", 
                InfuraAddress = ConfigurationManager.AppSettings["RinkebyInfura"]
            };
            _moralityPlayersBank = MoralityTokenBankFactory.GetMoralityPlayersBank(_adminTokenSettings);
        }

        [Test]
        public void MintCollectionTest()
        {
            var args = new MintCollectionArguments()
            {
                CollectionName = "Test Collection Beta",
                CollectionOwner = "0x5c9D8ed10c263F1bB02404145E7cE49CEC0D87F0",
                Description = "A Test",
                Name = "Test Collection Item",
                TokenPrice = 0.01,
                TotalToMint = 10
            };
            var transaction = AsyncHelper.RunSync(()=> _moralityPlayersBank.MintCollection(args));
            Assert.IsTrue(!string.IsNullOrEmpty(transaction));
        }

        [Test]
        public void GetCollectionItemPriceTest()
        {
            var collectionName = "Test Collection Beta";
            var value = AsyncHelper.RunSync(() => _moralityPlayersBank.GetCollectionItemPrice(collectionName));
            Assert.IsNotNull(value);
            Assert.IsTrue(value > 0);
        }

        [Test]
        public void BuyTokenFailTest()
        {
            var collectionName = "Test Collection Kilo";
            var value = AsyncHelper.RunSync(() => _moralityPlayersBank.GetCollectionItemPrice(collectionName));
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(() =>
                AsyncHelper.RunSync(() => _moralityPlayersBank.BuyItemFromCollection(collectionName, value))
            );
        }

        [Test]
        public void BuyTokenTest()
        {
            var collectionName = "Test Collection Beta";
            var value = AsyncHelper.RunSync(() => _moralityPlayersBank.GetCollectionItemPrice(collectionName));
            var transaction = AsyncHelper.RunSync(() => _moralityPlayersBank.BuyItemFromCollection(collectionName, value));
            Assert.IsTrue(!string.IsNullOrEmpty(transaction));
        }

    }
}
