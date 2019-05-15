using Bank;
using MoBank.Interfaces;
using Moq;
using Nethereum.Web3;
using NUnit.Framework;
using RateIt.Common.Models;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services;
using RateIt.Services.Interfaces;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RateIt.TestSuite.Service
{
    public class TokenV5Tests
    {
        private IMoralityTokenBank _bank;
        private IMoralityStorageBank _storageBank;
        private MoralityTokenSettings _adminTokenSettings;
        private MoralityTokenSettings _userTokenSettings;

        [SetUp]
        public void Setup()
        {
            var tokenAbi = "[{'constant':true,'inputs':[],'name':'creator','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'name','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'allContents','outputs':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'getUniqueContentIdCount','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'contentId','type':'uint256'}],'name':'getContentById','outputs':[{'components':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'','type':'tuple[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'moderators','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'totalSupply','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'articleId','type':'uint256'}],'name':'getAllContentForArticle','outputs':[{'components':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'','type':'tuple[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'balances','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'name':'subArticleIndexes','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'amount','type':'uint256'}],'name':'withdraw','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'potentialNewOwner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'decimals','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'burnAmount','type':'uint256'}],'name':'burn','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'addContentViaEvent','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'subArticleId','type':'uint256'}],'name':'getAllContentForSubArticle','outputs':[{'components':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'','type':'tuple[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_name','type':'string'},{'name':'_symbol','type':'string'}],'name':'setTokenInformation','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'getAllContentCount','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'_owner','type':'address'}],'name':'balanceOf','outputs':[{'name':'balance','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'burnAddress','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'acceptOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'target','type':'address'},{'name':'mintedAmount','type':'uint256'}],'name':'mintToken','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'subArticleId','type':'uint256'}],'name':'countContentForSubArticle','outputs':[{'name':'count','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_moderator','type':'address'}],'name':'removeModerator','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'owner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'symbol','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'name':'contentIndexes','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_to','type':'address'},{'name':'_value','type':'uint256'}],'name':'transfer','outputs':[{'name':'success','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_newModerator','type':'address'}],'name':'addModerator','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'getAllContentIds','outputs':[{'name':'','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'},{'name':'','type':'uint256'}],'name':'articleIndexes','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'addContent','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'articleId','type':'uint256'}],'name':'countContentForArticle','outputs':[{'name':'count','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'contentIdExists','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'deprecateContract','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'name':'_newOwner','type':'address'}],'name':'transferOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'','type':'uint256'}],'name':'uniqueContentIds','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[{'name':'_totalTokensToMint','type':'uint256'}],'payable':true,'stateMutability':'payable','type':'constructor'},{'payable':true,'stateMutability':'payable','type':'fallback'},{'anonymous':false,'inputs':[{'indexed':false,'name':'sender','type':'address'},{'indexed':false,'name':'amount','type':'uint256'}],'name':'LogFundsReceived','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'balanceBefore','type':'uint256'},{'indexed':false,'name':'amount','type':'uint256'},{'indexed':false,'name':'balanceAfter','type':'uint256'}],'name':'WithdrawLog','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'newName','type':'string'},{'indexed':false,'name':'newSymbol','type':'string'}],'name':'UpdatedTokenInformation','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'contentCreator','type':'address'},{'indexed':true,'name':'articleId','type':'uint256'},{'indexed':true,'name':'subArticleId','type':'uint256'},{'indexed':true,'name':'contentId','type':'uint256'},{'indexed':false,'name':'timestamp','type':'uint256'}],'name':'ContentAdded','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'contentCreator','type':'address'},{'indexed':true,'name':'articleId','type':'uint256'},{'indexed':true,'name':'subArticleId','type':'uint256'},{'indexed':true,'name':'contentId','type':'uint256'},{'indexed':false,'name':'timestamp','type':'uint256'},{'indexed':false,'name':'data','type':'string'}],'name':'ContentAddedViaEvent','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_moderator','type':'address'}],'name':'ModeratorAdded','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_moderator','type':'address'}],'name':'ModeratorRemoved','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'}],'name':'OwnershipTransferred','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'from','type':'address'},{'indexed':true,'name':'to','type':'address'},{'indexed':false,'name':'value','type':'uint256'}],'name':'Transfer','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'target','type':'address'},{'indexed':false,'name':'mintedAmount','type':'uint256'}],'name':'Minted','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'burner','type':'address'},{'indexed':false,'name':'burnedAmount','type':'uint256'}],'name':'Burned','type':'event'}]";
            var storageAbi = "[{'constant':true,'inputs':[{'name':'contentId','type':'uint256'}],'name':'getContentById','outputs':[{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'','type':'address'}],'name':'moderators','outputs':[{'name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'articleId','type':'uint256'},{'name':'page','type':'uint256'}],'name':'getPageForArticle','outputs':[{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'potentialNewOwner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'addContentViaEvent','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'subArticleId','type':'uint256'}],'name':'getAllContentIdsForSubArticle','outputs':[{'name':'','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'subArticleId','type':'uint256'},{'name':'page','type':'uint256'}],'name':'getPageForSubArticle','outputs':[{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'},{'name':'','type':'string'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'getAllContentCount','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[],'name':'acceptOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'subArticleId','type':'uint256'}],'name':'countContentForSubArticle','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_moderator','type':'address'}],'name':'removeModerator','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'owner','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_newModerator','type':'address'}],'name':'addModerator','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[],'name':'perPage','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'getAllContentIds','outputs':[{'name':'','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'contentCreator','type':'address'},{'name':'articleId','type':'uint256'},{'name':'subArticleId','type':'uint256'},{'name':'contentId','type':'uint256'},{'name':'timestamp','type':'uint256'},{'name':'data','type':'string'}],'name':'addContent','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':true,'inputs':[{'name':'articleId','type':'uint256'}],'name':'getAllContentIdsForArticle','outputs':[{'name':'','type':'uint256[]'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'name':'articleId','type':'uint256'}],'name':'countContentForArticle','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'_newOwner','type':'address'}],'name':'transferOwnership','outputs':[],'payable':false,'stateMutability':'nonpayable','type':'function'},{'anonymous':false,'inputs':[{'indexed':false,'name':'contentCreator','type':'address'},{'indexed':true,'name':'articleId','type':'uint256'},{'indexed':true,'name':'subArticleId','type':'uint256'},{'indexed':true,'name':'contentId','type':'uint256'},{'indexed':false,'name':'timestamp','type':'uint256'}],'name':'ContentAdded','type':'event'},{'anonymous':false,'inputs':[{'indexed':false,'name':'contentCreator','type':'address'},{'indexed':true,'name':'articleId','type':'uint256'},{'indexed':true,'name':'subArticleId','type':'uint256'},{'indexed':true,'name':'contentId','type':'uint256'},{'indexed':false,'name':'timestamp','type':'uint256'},{'indexed':false,'name':'data','type':'string'}],'name':'ContentAddedViaEvent','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_moderator','type':'address'}],'name':'ModeratorAdded','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_moderator','type':'address'}],'name':'ModeratorRemoved','type':'event'},{'anonymous':false,'inputs':[{'indexed':true,'name':'_from','type':'address'},{'indexed':true,'name':'_to','type':'address'}],'name':'OwnershipTransferred','type':'event'}]";
            var crowdAbi = "[{'constant':true,'inputs':[],'name':'rate','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'weiRaised','outputs':[{'name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[],'name':'wallet','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':false,'inputs':[{'name':'beneficiary','type':'address'}],'name':'buyTokens','outputs':[],'payable':true,'stateMutability':'payable','type':'function'},{'constant':true,'inputs':[],'name':'token','outputs':[{'name':'','type':'address'}],'payable':false,'stateMutability':'view','type':'function'},{'inputs':[{'name':'rate','type':'uint256'},{'name':'wallet','type':'address'},{'name':'token','type':'address'}],'payable':false,'stateMutability':'nonpayable','type':'constructor'},{'payable':true,'stateMutability':'payable','type':'fallback'},{'anonymous':false,'inputs':[{'indexed':true,'name':'purchaser','type':'address'},{'indexed':true,'name':'beneficiary','type':'address'},{'indexed':false,'name':'value','type':'uint256'},{'indexed':false,'name':'amount','type':'uint256'}],'name':'TokensPurchased','type':'event'}]";
            var contractAddress = "0xfb74e5ecf5044e743212e8c26d3a1c5ce005424d";
            var storageAddress = "0x2ba55422e6ec989a92d04d38e578f65c13e75874";
            var wrapperAddress = "0xee37d0fb069d3ea3c38ea34ee278a21c75341fa2";
            _adminTokenSettings = new MoralityTokenSettings()
            {
                TokenAbi = tokenAbi,
                StorageAbi = storageAbi,
                CrowdAbi = crowdAbi,
                AdminAddress = "0x5c9D8ed10c263F1bB02404145E7cE49CEC0D87F0",
                AdminPass = ConfigurationManager.AppSettings["AdminPK"] ,
                ContractAddress = contractAddress,
                WrapperAddress = wrapperAddress,
                StorageAddress = storageAddress,
                InfuraAddress = ConfigurationManager.AppSettings["RinkebyInfura"]
            };
            _userTokenSettings = new MoralityTokenSettings()
            {
                TokenAbi = tokenAbi,
                StorageAbi = storageAbi,
                CrowdAbi = crowdAbi,
                AdminAddress = "0x5E1970A7Caa3E95f314d70936E6384927594eB1e",
                AdminPass = ConfigurationManager.AppSettings["UserPK"],
                ContractAddress = contractAddress,
                StorageAddress = storageAddress,
                WrapperAddress = wrapperAddress,
                InfuraAddress = ConfigurationManager.AppSettings["RinkebyInfura"]
            };
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_adminTokenSettings);
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_adminTokenSettings);
        }

        private Common.Models.Comment GetExistingComment()
        {
            return new Common.Models.Comment()
            {
                ContentId = 3,
                CreatedAt = DateTime.Now,
                CreatedByAdmin = true,
                ModifiedAt = DateTime.Now,
                CreatorId = 4,
                FlagCount = 20,
                Fullname = "Testy McTesterson",
                ParentId = null,
                Content = "This is the first content added to the chain!",
                ProfilePictureUrl = "",
                SiteName = "www.google.com",
                UpvoteCount = 340
            };
        }

        private PageContent GetPageContent(Common.Models.Comment comment)
        {
            return new PageContent()
            {
                ContentType = Common.Models.Enums.ContentTypeMap.Comment,
                ContentId = comment.ContentId,
                SiteId = 3,
                SubDirectoryId = 34,
                TimestampCreated = DateTime.Now,
                Comment = comment
            };
        }

        //Transfer<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        [Test]
        public void TransferWeiToContract()
        {
            var transactionId = AsyncHelper.RunSync(()=> _bank.TransferEth(_adminTokenSettings.WrapperAddress, 0.00003));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void TransferTokensToCrowdsaleContract()
        {
            var transaction = AsyncHelper.RunSync(() => _bank.Transfer(_adminTokenSettings.WrapperAddress, 10000));
            Assert.IsNotNull(transaction);
            Assert.IsTrue(!string.IsNullOrEmpty(transaction.TransactionHash));
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Admin Util stuff
        [Test]
        public void AdminMintTest()
        {
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            var transactionId = AsyncHelper.RunSync(() => _bank.Mint(address, 1));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void UserMintTest()
        {
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_userTokenSettings);
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _bank.Mint(address, 1))
            );
        }

        [Test]
        public void AdminBurnTest()
        {
            var transactionId = AsyncHelper.RunSync(() => _bank.Burn(1));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void UserBurnTest()
        {
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_userTokenSettings);
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _bank.Burn(1))
            );
        }

        [Test]
        public void AdminWithdrawTest()
        {
            var oneWei = Web3.Convert.FromWei(new System.Numerics.BigInteger(1));
            var transactionId = AsyncHelper.RunSync(() => _bank.Withdraw((double)oneWei));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void UserWithdrawTest()
        {
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_userTokenSettings);
            var oneWei = Web3.Convert.FromWei(new System.Numerics.BigInteger(1));
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _bank.Withdraw((double)oneWei))
            );
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Moderator
        [Test]
        public void AdminDoesModeratorExistTrueTest()
        {
            var exists = AsyncHelper.RunSync(()=> _storageBank.DoesModeratorExist(_adminTokenSettings.AdminAddress));
            Assert.IsTrue(exists);
        }

        [Test]
        public void AdminDoesModeratorExistFalseTest()
        {
            var exists = AsyncHelper.RunSync(() => _storageBank.DoesModeratorExist(_userTokenSettings.AdminAddress));
            Assert.IsFalse(exists);
        }

        [Test]
        public void UserDoesModeratorExistTrueTest()
        {
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_userTokenSettings);
            var exists = AsyncHelper.RunSync(() => _storageBank.DoesModeratorExist(_adminTokenSettings.AdminAddress));
            Assert.IsTrue(exists);
        }

        [Test]
        public void UserDoesModeratorExistFalseTest()
        {
            _bank = MoralityTokenBankFactory.GetMoralityTokenBank(_userTokenSettings);
            var exists = AsyncHelper.RunSync(() => _storageBank.DoesModeratorExist(_userTokenSettings.AdminAddress));
            Assert.IsFalse(exists);
        }

        [Test]
        public void AdminAddModeratorTest()
        {
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            var transactionId = AsyncHelper.RunSync(() => _storageBank.AddModerator(address));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void UserAddModeratorTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _storageBank.AddModerator(address))
            );
        }

        [Test]
        public void AdminRemoveModeratorTest()
        {
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            var transactionId = AsyncHelper.RunSync(() => _storageBank.RemoveModerator(address));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionId));
        }

        [Test]
        public void UserRemoveModeratorTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var address = "0xDBaAfE0f8cc2D75dcD27879fc109d231547e7451";
            Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _storageBank.RemoveModerator(address))
            );
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Content (Admin)
        [Test]
        public void AdminAddContentViaEventTest()
        {
            var comment = GetExistingComment();
            var pageContent = GetPageContent(comment);
            var serializedComment = new JavaScriptSerializer().Serialize(pageContent);
            var transactionHash = AsyncHelper.RunSync(()=> _storageBank.AddContentViaEvent(1, 2, 3, serializedComment));
            Assert.IsTrue(!string.IsNullOrEmpty(transactionHash));
        }

        [Test]
        public void AdminGetContentViaEventTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetExactContentEvent(3));
            Assert.IsNotNull(content);
            Assert.AreEqual(content.ContentId, 3);
        }

        [Test]
        public void AdminGetContentByArticleViaEventTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentByArticleEvent(1));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
            foreach (var item in content)
            {
                Assert.AreEqual(1, item.ArticleId);
            }
        }

        [Test]
        public void AdminGetContentBySubArticleViaEventTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentBySubArticleEvent(2));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
            foreach (var item in content)
            {
                Assert.AreEqual(2, item.SubArticleId);
            }
        }

        [Test]
        public void AdminAddNewContentIdContentViaStructTest()
        {
            var comment = GetExistingComment();
            var pageContent = GetPageContent(comment);
            var serializedComment = new JavaScriptSerializer().Serialize(pageContent);
            var transactionHash = AsyncHelper.RunSync(() => _storageBank.AddContent(1, 2, 13, serializedComment));
            Assert.IsNotNull(transactionHash);
            Assert.IsTrue(transactionHash.Length > 0);
        }

        [Test]
        public void AdminGetContentByIdStructTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentById(13));
            Assert.IsNotNull(content);
            Assert.AreEqual(13, content.ContentId);
        }

        [Test]
        public void AdminGetAllContentIdsStructTest()
        {
            var ids = AsyncHelper.RunSync(() => _storageBank.GetAllContentIds());
            Assert.IsNotNull(ids);
            Assert.IsTrue(ids.Count() > 0);
        }

        [Test]
        public void AdminGetContentIdsByArticleIdStructTest()
        {
            var contentIds = AsyncHelper.RunSync(() => _storageBank.GetAllContentIdsForArticle(1));
            Assert.IsNotNull(contentIds);
            Assert.IsTrue(contentIds.Count() > 0);
        }

        [Test]
        public void AdminGetContentByArticleIdStructTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentByArticleId(1, 0));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
        }

        [Test]
        public void AdminGetContentIdsBySubArticleIdStructTest()
        {
            var contentIds = AsyncHelper.RunSync(() => _storageBank.GetAllContentIdsForSubArticle(2));
            Assert.IsNotNull(contentIds);
            Assert.IsTrue(contentIds.Count() > 0);
        }

        [Test]
        public void AdminGetContentBySubArticleIdStructTest()
        {
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentBySubArticleId(2, 0));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
        }

        [Test]
        public void AdminCountContentByArticleIdStructTest()
        {
            var contentCount = AsyncHelper.RunSync(() => _storageBank.CountAllContentForArticle(1));
            Assert.IsNotNull(contentCount);
            Assert.IsTrue(contentCount > 0);
        }

        [Test]
        public void AdminCountContentBySubArticleIdStructTest()
        {
            var contentCount = AsyncHelper.RunSync(() => _storageBank.CountAllContentForSubArticle(2));
            Assert.IsNotNull(contentCount);
            Assert.IsTrue(contentCount > 0);
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Content (User)
        [Test]
        public void UserAddContentViaEventTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var comment = GetExistingComment();
            var pageContent = GetPageContent(comment);
            var serializedComment = new JavaScriptSerializer().Serialize(pageContent);
            var transactionHash = Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
              () => AsyncHelper.RunSync(() => _storageBank.AddContentViaEvent(1, 2, ContentIdTracker.NextId(), serializedComment))
            );
        }

        [Test]
        public void UserGetContentViaEventTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetExactContentEvent(3));
            Assert.IsNotNull(content);
            Assert.AreEqual(content.ContentId, 3);
        }

        [Test]
        public void UserGetContentByArticleViaEventTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentByArticleEvent(1));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
            foreach (var item in content)
            {
                Assert.AreEqual(1, item.ArticleId);
            }
        }

        [Test]
        public void UserGetContentBySubArticleViaEventTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentBySubArticleEvent(2));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
            foreach (var item in content)
            {
                Assert.AreEqual(2, item.SubArticleId);
            }
        }

        [Test]
        public void UserAddExistingContentIdContentViaStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var comment = GetExistingComment();
            var pageContent = GetPageContent(comment);
            var serializedComment = new JavaScriptSerializer().Serialize(pageContent);
            var transactionHash = Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _storageBank.AddContent(1, 2, 10, serializedComment))
            );
        }

        [Test]
        public void UserAddNewContentIdContentViaStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var comment = GetExistingComment();
            var pageContent = GetPageContent(comment);
            var serializedComment = new JavaScriptSerializer().Serialize(pageContent);
            var transactionHash = Assert.Throws<Nethereum.JsonRpc.Client.RpcResponseException>(
                () => AsyncHelper.RunSync(() => _storageBank.AddContent(1, 2, 10, serializedComment))
            );
        }

        [Test]
        public void UserGetContentByIdStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentById(13));
            Assert.IsNotNull(content);
            Assert.IsTrue(!string.IsNullOrEmpty(content.Data));
        }

        [Test]
        public void UserGetAllContentIdsStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var ids = AsyncHelper.RunSync(() => _storageBank.GetAllContentIds());
            Assert.IsNotNull(ids);
            Assert.IsTrue(ids.Count() > 0);
        }

        [Test]
        public void UserGetContentByArticleIdStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentByArticleId(1, 0));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
        }

        [Test]
        public void UserGetContentBySubArticleIdStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var content = AsyncHelper.RunSync(() => _storageBank.GetContentBySubArticleId(2, 0));
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Count() > 0);
        }

        [Test]
        public void UserCountContentByArticleIdStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var contentCount = AsyncHelper.RunSync(() => _storageBank.CountAllContentForArticle(1));
            Assert.IsNotNull(contentCount);
            Assert.IsTrue(contentCount > 0);
        }

        [Test]
        public void UserCountContentBySubArticleIdStructTest()
        {
            _storageBank = MoralityTokenBankFactory.GetMoralityStorageBank(_userTokenSettings);
            var contentCount = AsyncHelper.RunSync(() => _storageBank.CountAllContentForSubArticle(2));
            Assert.IsNotNull(contentCount);
            Assert.IsTrue(contentCount > 0);
        }
    }
}
