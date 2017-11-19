
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/19/2017 15:52:31
-- Generated from EDMX file: T:\Personals\Repositories\UnivercityProjects\ITES_Labs\Lab1-Console\PowerConsumptionCalc\ClassLibrary1\PowerGridModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PowerGridDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BusBusConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusConnections] DROP CONSTRAINT [FK_BusBusConnection];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Buses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buses];
GO
IF OBJECT_ID(N'[dbo].[BusConnections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusConnections];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Buses'
CREATE TABLE [dbo].[Buses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(20)  NULL,
    [Voltage] int  NOT NULL,
    [Installed] datetime  NOT NULL
);
GO

-- Creating table 'BusConnections'
CREATE TABLE [dbo].[BusConnections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nchar(10)  NULL,
    [P] float  NULL,
    [Q] float  NULL,
    [BusId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Buses'
ALTER TABLE [dbo].[Buses]
ADD CONSTRAINT [PK_Buses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BusConnections'
ALTER TABLE [dbo].[BusConnections]
ADD CONSTRAINT [PK_BusConnections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BusId] in table 'BusConnections'
ALTER TABLE [dbo].[BusConnections]
ADD CONSTRAINT [FK_BusBusConnection]
    FOREIGN KEY ([BusId])
    REFERENCES [dbo].[Buses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusBusConnection'
CREATE INDEX [IX_FK_BusBusConnection]
ON [dbo].[BusConnections]
    ([BusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------