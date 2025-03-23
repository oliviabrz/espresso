-- espresso.Grinder definition

CREATE TABLE `Grinder` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BrandName` varchar(100) NOT NULL,
  `ModelName` varchar(75) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;