-- espresso.EspressoBean definition

CREATE TABLE `EspressoBean` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `RoastDate` date NOT NULL,
  `PurchasedDate` date NOT NULL,
  `PurchasedFrom` varchar(100) DEFAULT NULL,
  `RoastTypeId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `EspressoBean_RoastTypeLookuo_FK` (`RoastTypeId`),
  CONSTRAINT `EspressoBean_RoastTypeLookuo_FK` FOREIGN KEY (`RoastTypeId`) REFERENCES `RoastTypeLookup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
