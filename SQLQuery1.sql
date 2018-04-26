DROP TABLE [dbo].[Games];

CREATE TABLE [dbo].[Games] (
    [ID]          NVARCHAR (MAX) IDENTITY (1, 1) NOT NULL,
    [Comment]     NVARCHAR (300) NULL,
    [Rating]      INT            NOT NULL,
    [ReleaseYear] INT            NOT NULL,
    [Title]       NVARCHAR (60)  NOT NULL,
    [Consoles]    INT            DEFAULT ((0)) NOT NULL,
    [Genre]       INT            DEFAULT ((0)) NOT NULL,
    [UserName]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([ID] ASC)
);