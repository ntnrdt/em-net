/******************************
** File: RUNME.sql  
** Desc: Creates the table Events and all needed stored procedures.
** Auth: Natan Dutra
** Date: 2020-05-03 
**************************
** Change History
**************************
** PR   Date        Author  Description 
** --   --------   -------   ------------------------------------
*******************************/


/****************************************************************
 CREATE TABLE - EVENT
****************************************************************/

CREATE TABLE [dbo].[Events](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Date] [datetime],
	[Price] [decimal],
	[ImageUrl] [varchar](max),
	[Description] [varchar](max),
	[OnlineUrl] [varchar](max),
	[Address] [varchar](max),
	[City] [varchar](255),
	[Country] [varchar](255)

);

SELECT * FROM Events
GO

/****************************************************************
 END CREATE TABLE - EVENT
****************************************************************/


/****************************************************************
 CREATE STORED PROCEDURE - INSERT EVENT
****************************************************************/

CREATE PROCEDURE InsertEvent 
    @Title varchar(255), 
    @Description varchar(max) = NULL, 
    @Date datetime = NULL,
    @Price decimal = NULL,
    @ImageUrl varchar(max) = NULL,
    @OnlineUrl varchar(max) = NULL,
    @Address varchar(max) = NULL,
    @City varchar(255) = NULL,
    @Country varchar(255) = NULL
AS
BEGIN

    INSERT INTO [dbo].[Events] 
    (
        [Title], 
        [Description], 
        [Date],
        [Price], 
        [ImageUrl], 
        [OnlineUrl], 
        [Address], 
        [City], 
        [Country]
    ) 
    VALUES 
    (
        @Title, 
        @Description,
        @Date, 
        @Price, 
        @ImageUrl,
        @OnlineUrl, 
        @Address,
        @City,
        @Country
    );
END
GO

/****************************************************************
 END CREATE STORED PROCEDURE - INSERT EVENT
****************************************************************/


/****************************************************************
 CREATE STORED PROCEDURE - UPDATE EVENT
****************************************************************/

CREATE PROCEDURE UpdateEvent 
    @Id int,
    @Title varchar(255), 
    @Description varchar(max) = NULL, 
    @Date datetime = NULL,
    @Price decimal = NULL,
    @ImageUrl varchar(max) = NULL,
    @OnlineUrl varchar(max) = NULL,
    @Address varchar(max) = NULL,
    @City varchar(255) = NULL,
    @Country varchar(255) = NULL
AS
BEGIN

UPDATE [dbo].[Events] 
SET

    [Title] = @Title, 
    [Description] = @Description, 
    [Date] = @Date,
    [Price] = @Price, 
    [ImageUrl] = @ImageUrl, 
    [OnlineUrl] = @OnlineUrl, 
    [Address] = @Address, 
    [City] = @City, 
    [Country] = @Country

WHERE [Id] = @Id
    
END
GO

/****************************************************************
 END CREATE STORED PROCEDURE - UPDATE EVENT
****************************************************************/


/****************************************************************
 CREATE STORED PROCEDURE - DELETE EVENT
****************************************************************/

CREATE PROCEDURE DeleteEvent @Id int
AS
BEGIN

DELETE FROM [dbo].[Events] 
WHERE [Id] = @Id
    
END
GO

/****************************************************************
 END CREATE STORED PROCEDURE - DELETE EVENT
****************************************************************/


/****************************************************************
CREATE STORED PROCEDURE - SELECT EVENT
****************************************************************/

CREATE PROCEDURE SelectEvent @Id int
AS
BEGIN

SELECT * FROM [dbo].[Events] 
WHERE [Id] = @Id

END
GO

/****************************************************************
END CREATE STORED PROCEDURE - SELECT EVENT
****************************************************************/


/****************************************************************
CREATE STORED PROCEDURE - SELECT EVENTS
****************************************************************/

CREATE PROCEDURE SelectEvents
AS
BEGIN

SELECT * FROM [dbo].[Events]

END
GO

/****************************************************************
END CREATE STORED PROCEDURE - SELECT EVENTS
****************************************************************/
