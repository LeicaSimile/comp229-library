-- Angelica Catalan, 300846458
USE [LIBRARY.MDF]
GO

/****** Object: Table [dbo].[Book] Script Date: 12/1/2017 6:02:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Angelica Catalan, 300846458
CREATE TABLE [dbo].[Book] (
    [Id]           INT            NOT NULL,
    [Title]        NVARCHAR (100) NOT NULL,
    [Author]       NVARCHAR (100) NOT NULL,
    [Isbn]         NVARCHAR (13)  NULL,
    [Genre]        NVARCHAR (50)  NULL,
    [PageCount]    INT            NOT NULL,
    [FriendLanded] NVARCHAR (100) NULL,
    [Comments]     NVARCHAR (500) NULL
);


-- Angelica Catalan, 300846458