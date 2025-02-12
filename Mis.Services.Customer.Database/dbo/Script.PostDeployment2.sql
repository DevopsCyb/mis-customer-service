/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF (SELECT COUNT(*) from [dbo].[Customer]) = 0
BEGIN
    INSERT INTO [dbo].[Customer] (CustomerID, ContactPersonEmail, ContactPersonName, Mobile, Name)
    VALUES (1, 'xyz@cybage.com', 'cybage', '7458221', 'xyz'),
           (2, 'victra@cybage.com', 'cybage', '123456789', 'victra');
END
