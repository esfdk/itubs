-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/21/2013 11:29:02
-- Generated from EDMX file: C:\Users\Jakob Melnyk\Documents\GitHub\itubs\Test\Data\BookingDataModel.edmx
-- --------------------------------------------------

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_BookingPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingCateringChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CateringChoices] DROP CONSTRAINT [FK_BookingCateringChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_CateringChoiceCatering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caterings] DROP CONSTRAINT [FK_CateringChoiceCatering];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingEquipmentChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentChoices] DROP CONSTRAINT [FK_BookingEquipmentChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentEquipmentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_EquipmentEquipmentType];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentEquipmentChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentChoices] DROP CONSTRAINT [FK_EquipmentEquipmentChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_BookingRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventories] DROP CONSTRAINT [FK_RoomInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_InventoryTypeInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventories] DROP CONSTRAINT [FK_InventoryTypeInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonRoles] DROP CONSTRAINT [FK_PersonPersonRole];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePersonRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonRoles] DROP CONSTRAINT [FK_RolePersonRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Inventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventories];
GO
IF OBJECT_ID(N'[dbo].[Caterings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Caterings];
GO
IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[CateringChoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CateringChoices];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[EquipmentChoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentChoices];
GO
IF OBJECT_ID(N'[dbo].[EquipmentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentTypes];
GO
IF OBJECT_ID(N'[dbo].[InventoryTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventoryTypes];
GO
IF OBJECT_ID(N'[dbo].[PersonRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Token] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [NumberOfParticipants] int  NOT NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [PersonID] int  NOT NULL,
    [RoomID] int  NOT NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [RoomID] int  NOT NULL,
    [InventoryTypeID] int  NOT NULL
);
GO

-- Creating table 'Caterings'
CREATE TABLE [dbo].[Caterings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Price] int  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [AvailableFrom] time  NOT NULL,
    [AvailableTo] time  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [EquipmentTypeID] int  NOT NULL
);
GO

-- Creating table 'CateringChoices'
CREATE TABLE [dbo].[CateringChoices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Amount] int  NOT NULL,
    [Time] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [BookingID] int  NOT NULL,
    [CateringID] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MaxParticipants] int  NOT NULL
);
GO

-- Creating table 'EquipmentChoices'
CREATE TABLE [dbo].[EquipmentChoices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [BookingID] int  NOT NULL,
    [EquipmentID] int  NOT NULL
);
GO

-- Creating table 'EquipmentTypes'
CREATE TABLE [dbo].[EquipmentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InventoryTypes'
CREATE TABLE [dbo].[InventoryTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonRoles'
CREATE TABLE [dbo].[PersonRoles] (
    [PersonID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Caterings'
ALTER TABLE [dbo].[Caterings]
ADD CONSTRAINT [PK_Caterings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [PK_CateringChoices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [PK_EquipmentChoices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EquipmentTypes'
ALTER TABLE [dbo].[EquipmentTypes]
ADD CONSTRAINT [PK_EquipmentTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InventoryTypes'
ALTER TABLE [dbo].[InventoryTypes]
ADD CONSTRAINT [PK_InventoryTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PersonID], [RoleID] in table 'PersonRoles'
ALTER TABLE [dbo].[PersonRoles]
ADD CONSTRAINT [PK_PersonRoles]
    PRIMARY KEY NONCLUSTERED ([PersonID], [RoleID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_BookingPerson]
    FOREIGN KEY ([PersonID])
    REFERENCES [dbo].[People]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingPerson'
CREATE INDEX [IX_FK_BookingPerson]
ON [dbo].[Bookings]
    ([PersonID]);
GO

-- Creating foreign key on [BookingID] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [FK_BookingCateringChoice]
    FOREIGN KEY ([BookingID])
    REFERENCES [dbo].[Bookings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingCateringChoice'
CREATE INDEX [IX_FK_BookingCateringChoice]
ON [dbo].[CateringChoices]
    ([BookingID]);
GO

-- Creating foreign key on [BookingID] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [FK_BookingEquipmentChoice]
    FOREIGN KEY ([BookingID])
    REFERENCES [dbo].[Bookings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingEquipmentChoice'
CREATE INDEX [IX_FK_BookingEquipmentChoice]
ON [dbo].[EquipmentChoices]
    ([BookingID]);
GO

-- Creating foreign key on [EquipmentTypeID] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_EquipmentEquipmentType]
    FOREIGN KEY ([EquipmentTypeID])
    REFERENCES [dbo].[EquipmentTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentType'
CREATE INDEX [IX_FK_EquipmentEquipmentType]
ON [dbo].[Equipments]
    ([EquipmentTypeID]);
GO

-- Creating foreign key on [EquipmentID] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [FK_EquipmentEquipmentChoice]
    FOREIGN KEY ([EquipmentID])
    REFERENCES [dbo].[Equipments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentChoice'
CREATE INDEX [IX_FK_EquipmentEquipmentChoice]
ON [dbo].[EquipmentChoices]
    ([EquipmentID]);
GO

-- Creating foreign key on [RoomID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_BookingRoom]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRoom'
CREATE INDEX [IX_FK_BookingRoom]
ON [dbo].[Bookings]
    ([RoomID]);
GO

-- Creating foreign key on [RoomID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_RoomInventory]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomInventory'
CREATE INDEX [IX_FK_RoomInventory]
ON [dbo].[Inventories]
    ([RoomID]);
GO

-- Creating foreign key on [InventoryTypeID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_InventoryTypeInventory]
    FOREIGN KEY ([InventoryTypeID])
    REFERENCES [dbo].[InventoryTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryTypeInventory'
CREATE INDEX [IX_FK_InventoryTypeInventory]
ON [dbo].[Inventories]
    ([InventoryTypeID]);
GO

-- Creating foreign key on [PersonID] in table 'PersonRoles'
ALTER TABLE [dbo].[PersonRoles]
ADD CONSTRAINT [FK_PersonPersonRole]
    FOREIGN KEY ([PersonID])
    REFERENCES [dbo].[People]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleID] in table 'PersonRoles'
ALTER TABLE [dbo].[PersonRoles]
ADD CONSTRAINT [FK_RolePersonRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePersonRole'
CREATE INDEX [IX_FK_RolePersonRole]
ON [dbo].[PersonRoles]
    ([RoleID]);
GO

-- Creating foreign key on [CateringID] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [FK_CateringCateringChoice]
    FOREIGN KEY ([CateringID])
    REFERENCES [dbo].[Caterings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringCateringChoice'
CREATE INDEX [IX_FK_CateringCateringChoice]
ON [dbo].[CateringChoices]
    ([CateringID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------