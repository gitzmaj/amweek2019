CREATE TABLE [dbo].[Roles]
(
	[RoleCode] [nvarchar](128) NOT NULL,
	[RoleName] [nvarchar](max) NULL, 
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleCode]),
)
