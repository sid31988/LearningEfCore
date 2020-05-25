CREATE DATABASE ProductsDb
GO
USE ProductsDb
GO
CREATE TABLE ProductType (
    ProductTypeId Int IDENTITY(1,1) PRIMARY KEY,
    ProductTypeName VARCHAR(50),
    ProductTypeDesc VARCHAR(100)
)
GO
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(50),
    ProductDesc VARCHAR(100),
    ProductTypeId INT FOREIGN Key REFERENCES ProductType(ProductTypeId)
)
GO
INSERT into ProductType values ('Mobile', 'Mobile or Handheld devices')
GO
INSERT into ProductType values ('Tablet', 'Tablet devices')
GO
INSERT into ProductType values ('Laptop', 'Laptop devices')
GO

INSERT into Products values ('Samsung Galaxy S9', 'Android 9 smart phone', 1)
GO
INSERT into Products values ('Nokia N95', 'Symbian smart phone', 1)
GO
INSERT into Products values ('Apple IPhone 11', 'IOS smart phone', 1)
GO
INSERT into Products values ('HP Tablet', 'Hewlett Packard Tablet', 2)
GO
INSERT into Products values ('Acer Tablet', 'Acer Tablet', 2)
GO
INSERT into Products values ('Apple Tablet', 'Apple Tablet', 2)
GO
INSERT into Products values ('HP Laptop', 'Hewlett Packard Laptop', 3)
GO
INSERT into Products values ('Acer Laptop', 'Acer Laptop', 3)
GO
INSERT into Products values ('Apple Macbook', 'Apple Laptop', 3)
GO