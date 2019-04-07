/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Roles(RoleCode, RoleName) 
VALUES 
('-', N'--Not sharing'),
('TL', N'Technician'),
('ST', N'Senior Technician'),
('EN', N'Engineer'),
('SE', N'Senior Engineer'),
('CL', N'Consultant')


INSERT INTO Countries(CountryCode, CountryName)
VALUES
('-', N'--Not sharing'),
('RS', N'Serbia'),
('RO', N'Romania'),
('MK', N'Macedonia'),
('MD', N'Moldavia')