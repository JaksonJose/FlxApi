DROP TABLE IF exists dbo.Image;
CREATE TABLE dbo.Image (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ImageURL]		VARCHAR(2000) NULL,

	CreateDateTimeUTC datetime2 default getutcdate(),
	ModifyDateTimeUTC datetime2 default getutcdate(),
);

DROP TABLE IF exists dbo.Category;
CREATE TABLE dbo.Category (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ImageId]		INT FOREIGN KEY REFERENCES Image(Id) NULL,	
	[Name]			NVARCHAR(256),
	[Description]	TEXT,

	CreateDateTimeUTC datetime2 default getutcdate(),
	ModifyDateTimeUTC datetime2 default getutcdate(),
);

DROP TABLE IF exists dbo.Subcategory;
CREATE TABLE dbo.Subcategory (
	[Id]			INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryId]	INT FOREIGN KEY REFERENCES Category(Id) NOT NULL,
	[ImageId]		INT FOREIGN KEY REFERENCES Image(Id) NULL,	
	[Name]			NVARCHAR(256),
	[Description]	TEXT,

	CreateDateTimeUTC datetime2 default getutcdate(),
	ModifyDateTimeUTC datetime2 default getutcdate(),
);

DROP TABLE IF exists dbo.FlxUser;
CREATE TABLE dbo.FlxUser (
	[Id]				INT IDENTITY(1,1) NOT NULL,
	[UserName]			NVARCHAR(256) NOT NULL,
	[Email]				NVARCHAR(450) NOT NULL,
	[EmailConfirmed]	BIT NOT NULL,
	[PasswordHash]		VARCHAR(MAX) NOT NULL,
	[PasswordSalt]		VARCHAR(MAX) NOT NULL,
	[FirstName]			NVARCHAR(256) NULL,
	[LastName]			NVARCHAR(256) NULL,

	CreateDateTimeUTC datetime2 default getutcdate(),
	ModifyDateTimeUTC datetime2 default getutcdate(),
);