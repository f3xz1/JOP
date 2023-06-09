﻿--create database SHOP

 

CREATE TABLE [dbo]. [Categories] (
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
[Name] NVARCHAR(50) NULL
)

 


CREATE TABLE [dbo]. [Products] (
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
[CategoryId] INT NOT NULL, 
[Name] NVARCHAR(50) NULL, 
[Price] FLOAT NULL, 
[Quality] INT NULL,
[Description] NVARCHAR(MAX) NULL, 
[Image] NVARCHAR(MAX) NULL FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

 

CREATE TABLE [dbo]. [Users](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
[Name] NVARCHAR(50) NULL, 
[Email] NVARCHAR(MAX) NULL, 
[Login] NVARCHAR(50) NULL, 
[Password] NVARCHAR(50) NULL,
[Surname] NVARCHAR(50) NULL, 
[IsAdmin] BIT NULL)

 

CREATE TABLE TakenProducts (
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
CustomerId INT NOT NULL, 
ProductId INT NOT NULL, 
FOREIGN KEY (CustomerId) REFERENCES Users(Id),
FOREIGN KEY (ProductId) REFERENCES Products(Id));