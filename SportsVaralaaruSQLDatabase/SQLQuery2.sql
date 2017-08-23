CREATE TABLE [dbo].[Sports] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [SportName] NCHAR (10) NULL,
    [Type]      NCHAR (10) NULL,
    [Desc]      NCHAR (10) NULL,
    [Kind]      NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

