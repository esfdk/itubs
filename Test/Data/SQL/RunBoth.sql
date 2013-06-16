
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Generated from EDMX file: ~\itubs\Test\Data\BookingDataModel.edmx
-- --------------------------------------------------
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
IF OBJECT_ID(N'[dbo].[FK_CateringCateringChoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CateringChoices] DROP CONSTRAINT [FK_CateringCateringChoice];
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
    [InventoryTypeID] int  NOT NULL,
    [RoomID] int  NULL
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
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRoom'
CREATE INDEX [IX_FK_BookingRoom]
ON [dbo].[Bookings]
    ([RoomID]);
GO

-- Creating foreign key on [InventoryTypeID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_InventoryTypeInventory]
    FOREIGN KEY ([InventoryTypeID])
    REFERENCES [dbo].[InventoryTypes]
        ([ID])
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating foreign key on [RoleID] in table 'PersonRoles'
ALTER TABLE [dbo].[PersonRoles]
ADD CONSTRAINT [FK_RolePersonRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE CASCADE ON UPDATE CASCADE;

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
    ON DELETE CASCADE ON UPDATE CASCADE;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringCateringChoice'
CREATE INDEX [IX_FK_CateringCateringChoice]
ON [dbo].[CateringChoices]
    ([CateringID]);
GO

-- Creating foreign key on [RoomID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_RoomInventory]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([ID])
    ON DELETE CASCADE ON UPDATE CASCADE;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomInventory'
CREATE INDEX [IX_FK_RoomInventory]
ON [dbo].[Inventories]
    ([RoomID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
-- Roles and people
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (1, 'Student')
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (2, 'Staff')
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (3, 'Administrator')
SET IDENTITY_INSERT [dbo].[Roles] OFF

SET IDENTITY_INSERT [dbo].[People] ON
INSERT [dbo].[People] ([ID], [Name], [Email], [Token]) VALUES (1, 'Admin', 'Admin@BookIt.dk', '')
INSERT [dbo].[People] ([ID], [Name], [Email], [Token]) VALUES (2, 'Test User', 'test@bookit.dk', '')
INSERT [dbo].[People] ([ID], [Name], [Email], [Token]) VALUES (3, 'Frederik Lysgaard', 'frly@itu.dk', '')
INSERT [dbo].[People] ([ID], [Name], [Email], [Token]) VALUES (4, 'Jakob Melnyk', 'jmel@itu.dk', '')
INSERT [dbo].[People] ([ID], [Name], [Email], [Token]) VALUES (5, 'Emil Juul', 'ejuu@itu.dk', '')
SET IDENTITY_INSERT [dbo].[People] OFF

INSERT [dbo].[PersonRoles] ([PersonID], [RoleID]) VALUES (1, 3)
INSERT [dbo].[PersonRoles] ([PersonID], [RoleID]) VALUES (2, 1)
INSERT [dbo].[PersonRoles] ([PersonID], [RoleID]) VALUES (3, 2)
INSERT [dbo].[PersonRoles] ([PersonID], [RoleID]) VALUES (4, 3)
INSERT [dbo].[PersonRoles] ([PersonID], [RoleID]) VALUES (5, 1)

-- Types
SET IDENTITY_INSERT [dbo].[InventoryTypes] ON
INSERT [dbo].[InventoryTypes] ([ID], [Type]) VALUES (1, 'Bord')
INSERT [dbo].[InventoryTypes] ([ID], [Type]) VALUES (2, 'Stol')
INSERT [dbo].[InventoryTypes] ([ID], [Type]) VALUES (3, 'Computer')
SET IDENTITY_INSERT [dbo].[InventoryTypes] OFF

SET IDENTITY_INSERT [dbo].[EquipmentTypes] ON
INSERT [dbo].[EquipmentTypes] ([ID], [Type]) VALUES (1, 'Projektor')
INSERT [dbo].[EquipmentTypes] ([ID], [Type]) VALUES (2, 'Kamera')
INSERT [dbo].[EquipmentTypes] ([ID], [Type]) VALUES (3, 'Optager')
SET IDENTITY_INSERT [dbo].[EquipmentTypes] OFF

-- Caterings and equipments

SET IDENTITY_INSERT [dbo].[Equipments] ON
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (1, 'Projektor 350X', 'Virker', 1)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (2, 'Canon Kamera 150P', 'Virker', 2)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (3, 'Sony Kamera Xperia', 'Virker', 2)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (4, 'Sony HD Kamera', 'Virker', 2)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (5, 'HD Projektor', 'Virker', 1)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (6, 'Canon Lydoptager', 'Virker', 3)
INSERT [dbo].[Equipments] ([ID], [ProductName], [Status], [EquipmentTypeID]) VALUES (7, 'Canon HD Lydoptager', 'Virker', 3)
SET IDENTITY_INSERT [dbo].[Equipments] OFF

SET IDENTITY_INSERT [dbo].[Caterings] ON
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (1, 8, 'Kanelsnegl', '09:00:00', '13:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (2, 5, 'Kaffe', '09:00:00', '20:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (3, 25, 'Sandwich', '12:00:00', '16:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (4, 45, 'Oksebryst m. ris', '17:00:00', '19:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (5, 30, 'Rugbrød m. divers pålæg', '11:00:00', '15:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (6, 5, 'Te', '09:00:00', '20:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (8, 15, 'Faxe kondi', '09:00:00', '20:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (9, 40, 'Boller i karry', '17:00:00', '19:00:00' )
SET IDENTITY_INSERT [dbo].[Caterings] OFF

-- Rooms and inventories

SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (1, '2A01', 6)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (2, '2A03', 30)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (3, '2A05', 25)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (4, '2A07', 8)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (5, '2A09', 25)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (6, '3A01', 10)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (7, '3A03', 6)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (8, '3A05', 30)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (9, '3A07', 12)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (10, '3A09', 5)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (11, '4A01', 18)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (12, '4A03', 10)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (13, '4A05', 15)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (14, '4A07', 4)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (15, '4A09', 8)
SET IDENTITY_INSERT [dbo].[Rooms] OFF

SET IDENTITY_INSERT [dbo].[Inventories] ON
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (1, 'Hæve-sænke bord', 'Virker', 1, 1)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (2, 'Skrivebordsstol', 'Reperation', 2, 2)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (3, 'IBM X500', 'Virker', 3, 1)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (4, 'Lænestol', 'Virker', 2, NULL)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (7, 'Lænestol', 'Virker', 2, 3)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (8, 'Hæve-sænke bord', 'Virker', 1, NULL)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (9, 'Skrivebord', 'Virker', 1, 2)
SET IDENTITY_INSERT [dbo].[Inventories] OFF

-- Bookings

SET IDENTITY_INSERT [dbo].[Bookings] ON
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (1,'Godkendt',30,'Møde','2013-05-15 12:00:00', '2013-05-15T15:00:00', 3, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (2,'Pending',30,'Møde','2013-06-10T16:00:00', '2013-06-10T18:00:00', 4, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (3,'Pending',25,'Forlæsning','2013-06-02T15:00:00', '2013-06-02T18:00:00', 4, 3)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (4,'Pending',10,'Møde','2013-06-10T14:00:00', '2013-06-10T15:00:00', 3, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (5,'Godkendt',8,'Møde','2013-06-10T12:00:00', '2013-06-10T14:00:00', 2, 4)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (6,'Godkendt',12,'Møde','2013-06-25T10:00:00', '2013-06-25T18:00:00', 2, 5)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (7,'Godkendt',8,'Møde','2013-06-12T10:00:00', '2013-06-12T18:00:00', 3, 6)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (8,'Godkendt',6,'Møde','2013-06-12T16:00:00', '2013-06-12T18:00:00', 2, 7)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (9,'Godkendt',6,'Møde','2013-06-13T10:00:00', '2013-06-13T12:00:00', 3, 7)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (10,'Godkendt',12,'Møde','2013-06-14T10:00:00', '2013-06-14T12:00:00', 2, 8)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (11,'Godkendt',15,'Møde','2013-06-14T10:00:00', '2013-06-14T14:00:00', 3, 6)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (12,'Pending',20,'Møde','2013-06-14T10:00:00', '2013-06-14T16:00:00', 3, 7)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (13,'Pending',23,'Møde','2013-06-18T12:00:00', '2013-06-18T16:00:00', 5, 8)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (14,'Pending',17,'Møde','2013-06-19T09:00:00', '2013-06-19T16:00:00', 3, 8)
SET IDENTITY_INSERT [dbo].[Bookings] OFF

-- Choices

SET IDENTITY_INSERT [dbo].[CateringChoices] ON
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (1, 15, '2013-05-15 12:00:00', 'Godkendt', 1, 1)
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (2, 20, '2013-06-10 10:00:00', 'Godkendt', 2, 2)
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (3, 50, '2013-06-02 15:00:00', 'Godkendt', 3, 3)
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (4, 10, '2013-06-02 15:00:00', 'Godkendt', 7, 3)
SET IDENTITY_INSERT [dbo].[CateringChoices] OFF

SET IDENTITY_INSERT [dbo].[EquipmentChoices] ON
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (1, '2013-05-15 12:00:00', '2013-05-15 15:00:00', 1,1)
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (2, '2013-06-10 10:00:00', '2013-06-10 13:00:00', 7,2)
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (3, '2013-06-10 14:00:00', '2013-06-10 15:00:00', 3,2)
SET IDENTITY_INSERT [dbo].[EquipmentChoices] OFF