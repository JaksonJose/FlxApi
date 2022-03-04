
DROP TABLE IF exists dbo.Category;
CREATE TABLE dbo.Category (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name]			NVARCHAR(256),
	[Description]	TEXT,
);

DROP TABLE IF exists dbo.Subcategory;
CREATE TABLE dbo.Subcategory (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryId]	INT FOREIGN KEY REFERENCES Category(Id) NOT NULL,	
	[Name]			NVARCHAR(256),
	[Description]	TEXT,
);

DROP TABLE IF exists dbo.Image;
CREATE TABLE dbo.Image (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryId]	INT FOREIGN KEY REFERENCES Category(Id) NULL,
	[SubcategoryId] INT FOREIGN KEY REFERENCES Subcategory(Id) NULL,
	[UrlImg]		TEXT,
);