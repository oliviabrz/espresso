-- espresso.EspressoBean definition

CREATE TABLE espresso.EspressoBean (
	Id INT auto_increment NOT NULL,
	Name varchar(100) NOT NULL,
	RoastDate DATE NOT NULL,
	PurchasedDate DATE NOT NULL,
	PurchasedFrom varchar(100) NULL,
	RoastType varchar(100) NULL,
	CONSTRAINT EspressoBean_PK PRIMARY KEY (Id)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8mb4
COLLATE=utf8mb4_0900_ai_ci;
