CREATE TABLE [dbo].[Prajitura] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Denumire]       NVARCHAR (MAX) NULL,
    [Cofetar]        NVARCHAR (MAX) NULL,
    [Pret]           DECIMAL (6, 2) NOT NULL,
    [DataPrepararii] DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,

    CONSTRAINT [PK_Prajitura] PRIMARY KEY CLUSTERED ([ID] ASC)
);