IF(db_id(N'FISH') IS NULL)
	BEGIN
		CREATE DATABASE FISH
	END
GO

USE FISH;
GO

CREATE TABLE [Category] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[IsActive] BIT NULL,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL
	CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Category] ADD CONSTRAINT [DF_Category_CreationDate] DEFAULT (sysdatetime()) FOR CreationDate;
GO
ALTER TABLE [Category] ADD CONSTRAINT [DF_Category_ModificationDate] DEFAULT (sysdatetime()) FOR ModificationDate;
GO

CREATE TABLE [Product](
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[CategoryId] BIGINT NULL,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[Quality] INT NULL DEFAULT 0,
	[IsActive] BIT DEFAULT 0,
	[Price] FLOAT(53) DEFAULT 0,
	[PromotionPrice] FLOAT(53) DEFAULT 0,
	[SeoPageTitle] VARCHAR(255) NULL,
	[SeoAlias] VARCHAR(150) NULL,
	[SeoKeywords] VARCHAR(50),
	[SeoDescription] VARCHAR(255),
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	[ImageInfo] NVARCHAR(MAX) NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Product] ADD CONSTRAINT [DF_Product_CreationDate] DEFAULT (sysdatetime()) FOR CreationDate;
GO
ALTER TABLE [Product] ADD CONSTRAINT [DF_Product_ModificationDate] DEFAULT (sysdatetime()) FOR ModificationDate;
GO
ALTER TABLE [Product] ADD CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]);
GO

CREATE TABLE [Role](
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NULL,
	[Description] NVARCHAR(255) NULL,
	[IsActive] BIT DEFAULT 1,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Role] ADD CONSTRAINT [DF_Role_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [Role] ADD CONSTRAINT [DF_Role_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO

CREATE TABLE [Member] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[FirstName] VARCHAR(150) NOT NULL,
	[LastName] VARCHAR(150) NOT NULL,
	[Address] VARCHAR(500) NOT NULL,
	[Phone] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(150) NOT NULL,
	[PIN] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(150) NOT NULL,
	[State] NVARCHAR(150) NULL,
	[Country] NVARCHAR(150) NOT NULL,
	[ZipCode] NVARCHAR(20) NULL,
	[IsActive] BIT DEFAULT 1,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_Member] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Member] ADD CONSTRAINT [DF_Member_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [Member] ADD CONSTRAINT [DF_Member_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO
CREATE NONCLUSTERED INDEX IX_Member_Search ON [Member]([FirstName], [LastName], [Country], [State], [City])
GO

CREATE TABLE [Bill] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[BillNumber] UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	[MemberId] BIGINT NOT NULL,
	[Total] FLOAT(53) NOT NULL,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_Bill] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Bill] ADD CONSTRAINT [DF_Bill_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [Bill] ADD CONSTRAINT [DF_Bill_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO
ALTER TABLE [Bill] ADD CONSTRAINT [FK_Bill_Member] FOREIGN KEY (MemberId) REFERENCES [Member]([Id])
GO
CREATE NONCLUSTERED INDEX IX_Bill_Search ON [Bill]([BillNumber], [CreationDate])
GO

CREATE TABLE [BillDetail] (
	[Id] BIGINT NOT NULL,
	[ProductId] BIGINT NOT NULL,
	[Quality] INT NOT NULL DEFAULT 0,
	[Price] FLOAT(53) NOT NULL,
	[IsReturn] BIT NULL DEFAULT 0 ,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_BillDetail] PRIMARY KEY ([Id], [ProductId])
)
GO
ALTER TABLE [BillDetail] ADD CONSTRAINT [DF_BillDetail_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [BillDetail] ADD CONSTRAINT [DF_BillDetail_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO
ALTER TABLE [BillDetail] ADD CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY ([Id]) REFERENCES [Member]([Id])
GO

CREATE TABLE [Menu] (
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Code] NVARCHAR(200) NOT NULL,
	[Url] NVARCHAR(300),
	[Image] NVARCHAR(300),
	[MenuType] INT NOT NULL DEFAULT 2,
	[HasSub] BIT DEFAULT 0,
	[IsActive] BIT DEFAULT 1,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_Menu] PRIMARY KEY ([Id])
)
GO
ALTER TABLE [Menu] ADD CONSTRAINT [DF_Menu_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [Menu] ADD CONSTRAINT [DF_Menu_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO

CREATE TABLE [SubMenu] (
	[Id] INT IDENTITY(1,1) NOT NULL,
	[ParentId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Code] NVARCHAR(100) NOT NULL,
	[Url] NVARCHAR(300),
	[Image] NVARCHAR(300),
	[IsActive] BIT DEFAULT 1,
	[CreationDate] DATETIME2(7) NOT NULL,
	[ModificationDate] DATETIME2(7) NOT NULL,
	CONSTRAINT [PK_SubMenu] PRIMARY KEY ([Id])
)
GO
ALTER TABLE [SubMenu] ADD CONSTRAINT [DF_SubMenu_CreationDate] DEFAULT (sysdatetime()) FOR [CreationDate]
GO
ALTER TABLE [SubMenu] ADD CONSTRAINT [DF_SubMenu_ModificationDate] DEFAULT (sysdatetime()) FOR [ModificationDate]
GO
ALTER TABLE [SubMenu] ADD CONSTRAINT [FK_SubMenu_Menu] FOREIGN KEY ([ParentId]) REFERENCES [Menu]([Id])
GO