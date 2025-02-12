CREATE TABLE [dbo].[Customer] (
    [CustomerID]         INT           NOT NULL,
    [ContactPersonEmail] VARCHAR (255) NOT NULL,
    [ContactPersonName]  VARCHAR (255) NOT NULL,
    [Mobile]             VARCHAR (255) NOT NULL,
    [Name]               VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

