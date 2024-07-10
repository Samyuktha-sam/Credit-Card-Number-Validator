-- Create the database if it does not exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CreditCardValidation')
BEGIN
    CREATE DATABASE CreditCardValidation;
END
GO

-- Use the newly created database
USE CreditCardValidation;
GO

-- Create the CardTypes table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CardTypes')
BEGIN
    CREATE TABLE CardTypes (
        CardTypeID INT PRIMARY KEY IDENTITY(1,1),
        CardTypeName VARCHAR(50) NOT NULL,
        Prefix VARCHAR(10) NOT NULL,
        Length INT NOT NULL
    );
END
GO

-- Create the ValidationRequests table if it does not exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ValidationRequests')
BEGIN
    CREATE TABLE ValidationRequests (
        RequestID INT PRIMARY KEY IDENTITY(1,1),
        CreditCardNumber VARCHAR(20) NOT NULL,
        IsValid BIT NOT NULL,
        CardType VARCHAR(50),
		ResultMsg VARCHAR(500),
        Timestamp DATETIME DEFAULT GETDATE()
    );
END
GO

-- Insert master data into CardTypes table if it does not exist
IF NOT EXISTS (SELECT * FROM CardTypes)
BEGIN
    INSERT INTO CardTypes (CardTypeName, Prefix, Length) VALUES
    ('Visa', '4', 16),
    ('MasterCard', '51', 16),
    ('MasterCard', '52', 16),
    ('MasterCard', '53', 16),
    ('MasterCard', '54', 16),
    ('MasterCard', '55', 16),
    ('MasterCard', '22', 16),
    ('AmEx', '34', 15),
    ('AmEx', '37', 15),
    ('Discover', '6011', 16);
END
GO
