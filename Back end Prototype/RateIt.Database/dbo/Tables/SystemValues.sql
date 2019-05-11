CREATE TABLE [dbo].[SystemValues]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [AmountToPayForTraining] FLOAT NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [AdminUserId] BIGINT NOT NULL, 
	[AirdropMaxGiveAway] BIGINT NOT NULL, 
	[AirdropDailyDistributeAmount] BIGINT NOT NULL, 
	[AirdropThresholdBigPrizeGiveAway] BIGINT NOT NULL, 
	[AirdropRandomDistribution] BIGINT NOT NULL, 
	[AirdropMaxRandomAmount] BIGINT NOT NULL, 
	[AirdropTotalUserCountMinThreshold] INT NOT NULL, 
	[AirdropMinThresholdUserPercent] INT NOT NULL, 
	[AirdropMaxThresholdUserPercent] INT NOT NULL, 
    [ValidationUserMaxCount] INT NOT NULL, 
    [ValidationUserThresholdPercent] FLOAT NOT NULL DEFAULT 80, 
    [ValidationUserMaxRunCount] INT NOT NULL DEFAULT 3, 
    [AmountToPayForUserValidation] FLOAT NOT NULL DEFAULT 0.0, 
    CONSTRAINT [FK_SystemValues_ToUsers] FOREIGN KEY ([AdminUserId]) REFERENCES [Users]([Id])
)

 /*
     public static BigInteger MaxGiveAway = 10000000;
     public static BigInteger DailyDistributeAmount = 10000;
     public static BigInteger ThresholdBigPrizeGiveAway = 50000;
     public static BigInteger RandomDistribution = 90;
     public static BigInteger MaxRandomAmount = 100000000000000000;
     public static int TotalUserCountMinThreshold = 500;
     public static int MinThresholdUserPercent = 10;
     public static int MaxThresholdUserPercent = 20;
     public static int AdminUserId = 1;
*/

