-- espresso.JournalEntry definition

CREATE TABLE `JournalEntry` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EspressoBeanId` int NOT NULL,
  `GrinderId` int NOT NULL,
  `GrindSetting` tinyint unsigned NOT NULL DEFAULT '0',
  `BeanWeightInGrams` tinyint unsigned NOT NULL DEFAULT '0',
  `PreExtractionTimeInSeconds` tinyint unsigned NOT NULL DEFAULT '0',
  `ExtractionTimeInSeconds` tinyint unsigned NOT NULL DEFAULT '0',
  `EspressoWeightInGrams` tinyint unsigned NOT NULL DEFAULT '0',
  `BitternessRank` tinyint unsigned NOT NULL DEFAULT '0',
  `AcidityRank` tinyint unsigned NOT NULL DEFAULT '0',
  `SourRank` tinyint unsigned NOT NULL DEFAULT '0',
  `CremaRank` tinyint unsigned NOT NULL DEFAULT '0',
  `SatisfactionRank` tinyint unsigned NOT NULL DEFAULT '0',
  `Comments` varchar(1000) DEFAULT NULL,
  `DateCreate` datetime NOT NULL,
  `DateUpdate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `JournalEntry_EspressoBean_FK` (`EspressoBeanId`),
  KEY `JournalEntry_Grinder_FK` (`GrinderId`),
  CONSTRAINT `JournalEntry_EspressoBean_FK` FOREIGN KEY (`EspressoBeanId`) REFERENCES `EspressoBean` (`Id`),
  CONSTRAINT `JournalEntry_Grinder_FK` FOREIGN KEY (`GrinderId`) REFERENCES `Grinder` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;