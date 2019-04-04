CREATE TABLE [dbo].[Countries]
(
	[CountryCode] [nvarchar](128) NOT NULL,
	[CountryName] [nvarchar](max) NULL, 
    CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryCode]),
)
