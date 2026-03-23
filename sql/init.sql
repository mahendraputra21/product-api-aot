CREATE DATABASE ProductDb
GO

USE ProductDb
GO

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Price DECIMAL(18,2)
)
GO

INSERT INTO Products (Name, Price)
VALUES
('Keyboard',500000),
('Mouse',200000),
('Monitor',3000000)
GO
