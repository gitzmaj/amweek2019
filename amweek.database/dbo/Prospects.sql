CREATE TABLE [dbo].[Prospects]
(
	[ProspectId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[Country_CountryCode] [nvarchar](128) NULL,
	[Role_RoleCode] [nvarchar](128) NULL, 
    CONSTRAINT [PK_Prospects] PRIMARY KEY ([ProspectId]), 
    CONSTRAINT [FK_Prospects_ToCountries] FOREIGN KEY ([Country_CountryCode]) REFERENCES [dbo].[Countries] ([CountryCode]),
	CONSTRAINT [FK_Prospects_ToRoles] FOREIGN KEY([Role_RoleCode]) REFERENCES [dbo].[Roles] ([RoleCode])
)
