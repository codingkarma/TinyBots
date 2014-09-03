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
Insert into Robot Values ('test1', 10, 10, 50, 10, 'robot.png')
Insert into Robot Values ('test2', 10, 10, 50, 10, 'robot.png')
Insert into Robot Values ('test3', 10, 10, 50, 10, 'robot.png')
Insert into Robot Values ('test4', 10, 10, 50, 10, 'robot.png')
Insert into Robot Values ('test5', 10, 10, 50, 10, 'robot.png')
