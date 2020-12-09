
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2020 13:25:13
-- Generated from EDMX file: C:\CustomerVS2019Projects\iCepts\CustomerPortal\CustomerPortal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CustomerAPi_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BC365Tenant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BC365Tenant];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BC365Tenant'
CREATE TABLE [dbo].[BC365Tenant] (
    [TenantId] varchar(50)  NOT NULL,
    [Environment] varchar(50)  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [APIVersion] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TenantId] in table 'BC365Tenant'
ALTER TABLE [dbo].[BC365Tenant]
ADD CONSTRAINT [PK_BC365Tenant]
    PRIMARY KEY CLUSTERED ([TenantId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------