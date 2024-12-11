-- espresso.Grinder definition

CREATE TABLE `Grinder` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BrandName` varchar(100) NOT NULL,
  `Model` varchar(75) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;