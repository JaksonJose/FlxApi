DROP TABLE IF exists dbo.Category;
CREATE TABLE dbo.Category (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ImageId]		INT FOREIGN KEY REFERENCES Image(Id) NULL,	
	[Name]			NVARCHAR(256),
	[Description]	TEXT,
);

DROP TABLE IF exists dbo.Subcategory;
CREATE TABLE dbo.Subcategory (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryId]	INT FOREIGN KEY REFERENCES Category(Id) NOT NULL,
	[ImageId]		INT FOREIGN KEY REFERENCES Image(Id) NULL,	
	[Name]			NVARCHAR(256),
	[Description]	TEXT,
);

DROP TABLE IF exists dbo.Image;
CREATE TABLE dbo.Image (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ImageURL]		VARCHAR(2000) NULL
);

DROP TABLE IF exists dbo.FlxUser;
CREATE TABLE dbo.FlxUser (
	[UserId]		NVARCHAR(450) NOT NULL,
	[Name]			NVARCHAR(450) NOT NULL,
	[Email]			NVARCHAR(450) NOT NULL,
	[PasswordHash]	NVARCHAR(MAX) NOT NULL,
);