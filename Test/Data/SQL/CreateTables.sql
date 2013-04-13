
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2013 16:53:06
-- Generated from EDMX file: C:\Users\Jakob Melnyk\Documents\GitHub\itubs\Test\DataModel\BookingDataModel.edmx
-- --------------------------------------------------
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InventoryTypeInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventories] DROP CONSTRAINT [FK_InventoryTypeInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_InventoryRoomInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomInventories] DROP CONSTRAINT [FK_InventoryRoomInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomRoomInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomInventories] DROP CONSTRAINT [FK_RoomRoomInventory];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentEquipmentChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentChoices] DROP CONSTRAINT [FK_EquipmentEquipmentChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_CateringCateringChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CateringChoices] DROP CONSTRAINT [FK_CateringCateringChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingCateringChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CateringChoices] DROP CONSTRAINT [FK_BookingCateringChoice];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentTypeEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_EquipmentTypeEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_CateringTypeCatering]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caterings] DROP CONSTRAINT [FK_CateringTypeCatering];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_RoomBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People] DROP CONSTRAINT [FK_PersonRole];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_PersonBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingEquipmentChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentChoices] DROP CONSTRAINT [FK_BookingEquipmentChoice];
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
IF OBJECT_ID(N'[dbo].[RoomInventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomInventories];
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
IF OBJECT_ID(N'[dbo].[CateringTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CateringTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [NumberOfParticipants] nvarchar(max)  NOT NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [EquipmentChoiceId] int  NOT NULL,
    [RoomId] int  NOT NULL,
    [PersonId] int  NOT NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [iProductName] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [InventoryTypeId] int  NOT NULL
);
GO

-- Creating table 'Caterings'
CREATE TABLE [dbo].[Caterings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [cProductName] nvarchar(max)  NOT NULL,
    [CateringTypeId] int  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [eProductName] nvarchar(max)  NOT NULL,
    [EquipmentTypeId] int  NOT NULL
);
GO

-- Creating table 'CateringChoices'
CREATE TABLE [dbo].[CateringChoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [BookingId] int  NOT NULL,
    [Catering_Id] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RoomInventories'
CREATE TABLE [dbo].[RoomInventories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [InventoryId] int  NOT NULL,
    [RoomId] int  NOT NULL
);
GO

-- Creating table 'EquipmentChoices'
CREATE TABLE [dbo].[EquipmentChoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] nvarchar(max)  NOT NULL,
    [EndTime] nvarchar(max)  NOT NULL,
    [BookingId] int  NOT NULL,
    [Equipment_Id] int  NOT NULL
);
GO

-- Creating table 'EquipmentTypes'
CREATE TABLE [dbo].[EquipmentTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [eType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InventoryTypes'
CREATE TABLE [dbo].[InventoryTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [iType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CateringTypes'
CREATE TABLE [dbo].[CateringTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cType] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Caterings'
ALTER TABLE [dbo].[Caterings]
ADD CONSTRAINT [PK_Caterings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [PK_CateringChoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomInventories'
ALTER TABLE [dbo].[RoomInventories]
ADD CONSTRAINT [PK_RoomInventories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [PK_EquipmentChoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentTypes'
ALTER TABLE [dbo].[EquipmentTypes]
ADD CONSTRAINT [PK_EquipmentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InventoryTypes'
ALTER TABLE [dbo].[InventoryTypes]
ADD CONSTRAINT [PK_InventoryTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CateringTypes'
ALTER TABLE [dbo].[CateringTypes]
ADD CONSTRAINT [PK_CateringTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InventoryTypeId] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_InventoryTypeInventory]
    FOREIGN KEY ([InventoryTypeId])
    REFERENCES [dbo].[InventoryTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryTypeInventory'
CREATE INDEX [IX_FK_InventoryTypeInventory]
ON [dbo].[Inventories]
    ([InventoryTypeId]);
GO

-- Creating foreign key on [InventoryId] in table 'RoomInventories'
ALTER TABLE [dbo].[RoomInventories]
ADD CONSTRAINT [FK_InventoryRoomInventory]
    FOREIGN KEY ([InventoryId])
    REFERENCES [dbo].[Inventories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryRoomInventory'
CREATE INDEX [IX_FK_InventoryRoomInventory]
ON [dbo].[RoomInventories]
    ([InventoryId]);
GO

-- Creating foreign key on [RoomId] in table 'RoomInventories'
ALTER TABLE [dbo].[RoomInventories]
ADD CONSTRAINT [FK_RoomRoomInventory]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomRoomInventory'
CREATE INDEX [IX_FK_RoomRoomInventory]
ON [dbo].[RoomInventories]
    ([RoomId]);
GO

-- Creating foreign key on [Equipment_Id] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [FK_EquipmentEquipmentChoice]
    FOREIGN KEY ([Equipment_Id])
    REFERENCES [dbo].[Equipments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentChoice'
CREATE INDEX [IX_FK_EquipmentEquipmentChoice]
ON [dbo].[EquipmentChoices]
    ([Equipment_Id]);
GO

-- Creating foreign key on [Catering_Id] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [FK_CateringCateringChoice]
    FOREIGN KEY ([Catering_Id])
    REFERENCES [dbo].[Caterings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringCateringChoice'
CREATE INDEX [IX_FK_CateringCateringChoice]
ON [dbo].[CateringChoices]
    ([Catering_Id]);
GO

-- Creating foreign key on [BookingId] in table 'CateringChoices'
ALTER TABLE [dbo].[CateringChoices]
ADD CONSTRAINT [FK_BookingCateringChoice]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingCateringChoice'
CREATE INDEX [IX_FK_BookingCateringChoice]
ON [dbo].[CateringChoices]
    ([BookingId]);
GO

-- Creating foreign key on [EquipmentTypeId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_EquipmentTypeEquipment]
    FOREIGN KEY ([EquipmentTypeId])
    REFERENCES [dbo].[EquipmentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentTypeEquipment'
CREATE INDEX [IX_FK_EquipmentTypeEquipment]
ON [dbo].[Equipments]
    ([EquipmentTypeId]);
GO

-- Creating foreign key on [CateringTypeId] in table 'Caterings'
ALTER TABLE [dbo].[Caterings]
ADD CONSTRAINT [FK_CateringTypeCatering]
    FOREIGN KEY ([CateringTypeId])
    REFERENCES [dbo].[CateringTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringTypeCatering'
CREATE INDEX [IX_FK_CateringTypeCatering]
ON [dbo].[Caterings]
    ([CateringTypeId]);
GO

-- Creating foreign key on [RoomId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_RoomBooking]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomBooking'
CREATE INDEX [IX_FK_RoomBooking]
ON [dbo].[Bookings]
    ([RoomId]);
GO

-- Creating foreign key on [Role_Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [FK_PersonRole]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRole'
CREATE INDEX [IX_FK_PersonRole]
ON [dbo].[People]
    ([Role_Id]);
GO

-- Creating foreign key on [PersonId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_PersonBooking]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonBooking'
CREATE INDEX [IX_FK_PersonBooking]
ON [dbo].[Bookings]
    ([PersonId]);
GO

-- Creating foreign key on [BookingId] in table 'EquipmentChoices'
ALTER TABLE [dbo].[EquipmentChoices]
ADD CONSTRAINT [FK_BookingEquipmentChoice]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingEquipmentChoice'
CREATE INDEX [IX_FK_BookingEquipmentChoice]
ON [dbo].[EquipmentChoices]
    ([BookingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------