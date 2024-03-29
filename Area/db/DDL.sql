DROP DATABASE IF EXISTS TT_DB;
CREATE DATABASE TT_DB;

GO

USE TT_DB;

CREATE TABLE Products
(
	Id INTEGER PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(256),
	Price SMALLMONEY
);

CREATE TABLE Categories
(
	Id INTEGER PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(256)
);

CREATE TABLE ProductCategories
(
	ProductId INTEGER NOT NULL,
	CategoryId INTEGER NOT NULL,
	CONSTRAINT "PK_ProductCategories" PRIMARY KEY ("ProductId", "CategoryId") ,
	CONSTRAINT "FK_ProductCategories_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_ProductCategories_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);