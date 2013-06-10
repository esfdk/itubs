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
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (5, 30, 'Rygbrød m. divers pålæg', '11:00:00', '15:00:00' )
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
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (2, 'Skrivebordsstol', 'Reparation', 2, 2)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (3, 'IBM X500', 'Virker', 3, 1)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (4, 'Lænestol', 'Virker', 2, NULL)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (7, 'Læder Lænestol', 'Virker', 2, 3)
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
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (6,'Godkendt',12,'Møde','2013-06-10T10:00:00', '2013-06-10T18:00:00', 2, 5)
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