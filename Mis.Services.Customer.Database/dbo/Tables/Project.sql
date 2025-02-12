CREATE TABLE [dbo].[Project] (
    [ProjectID]        INT  NOT NULL,
    [ProjectStartDate] DATE NULL,
    [ProjectEndDate]   DATE NULL,
    [CustomerID]       INT  NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ProjectID] ASC),
    CONSTRAINT [FK_Project_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

