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
SET IDENTITY_INSERT [dbo].[Equipments] OFF

SET IDENTITY_INSERT [dbo].[Caterings] ON
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (1, 8, 'Kanelsnegl', '09:00:00', '13:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (2, 5, 'Kaffe/Te', '09:00:00', '20:00:00' )
INSERT [dbo].[Caterings] ([ID], [Price], [ProductName], [AvailableFrom], [AvailableTo]) VALUES (3, 30, 'Sandwich', '12:00:00', '16:00:00' )
SET IDENTITY_INSERT [dbo].[Caterings] OFF

-- Rooms and inventories

SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (1, '2A12', 30)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (2, '3A14', 60)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (3, 'Audi2', 124)
INSERT [dbo].[Rooms] ([ID], [Name], [MaxParticipants]) VALUES (4, '5A56', 45)
SET IDENTITY_INSERT [dbo].[Rooms] OFF

SET IDENTITY_INSERT [dbo].[Inventories] ON
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (1, 'Rejse-sænke bord', 'Virker', 1, 1)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (2, 'Skrivebords stol', 'Reperation', 2, 1)
INSERT [dbo].[Inventories] ([ID], [ProductName], [Status], [InventoryTypeID], [RoomID]) VALUES (3, 'IBM X500', 'Virker', 3, 1)
SET IDENTITY_INSERT [dbo].[Inventories] OFF

-- Bookings

SET IDENTITY_INSERT [dbo].[Bookings] ON
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (1,'Godkendt',30,'Møde','2013-05-15 12:00:00', '2013-05-15T15:00:00', 3, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (2,'Pending',50,'Møde','2013-06-10T16:00:00', '2013-06-10T18:00:00', 4, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (3,'Godkendt',100,'Forlæsning','2013-06-02T15:00:00', '2013-06-02T18:00:00', 4, 3)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (4,'Godkendt',50,'Møde','2013-06-10T14:00:00', '2013-06-10T15:00:00', 3, 2)
INSERT [dbo].[Bookings] ( [ID], [Status], [NumberOfParticipants], [Comments], [StartTime], [EndTime], [PersonID], [RoomID]) VALUES (5,'Godkendt',50,'Møde','2013-06-10T10:00:00', '2013-06-10T18:00:00', 2, 3)
SET IDENTITY_INSERT [dbo].[Bookings] OFF

-- Choices

SET IDENTITY_INSERT [dbo].[CateringChoices] ON
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (1, 15, '2013-05-15 12:00:00', 'Godkendt', 1, 1)
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (2, 20, '2013-06-10 10:00:00', 'Godkendt', 2, 2)
INSERT [dbo].[CateringChoices] ([ID], [Amount], [Time], [Status], [BookingID], [CateringID]) VALUES (3, 50, '2013-06-02 15:00:00', 'Godkendt', 3, 3)
SET IDENTITY_INSERT [dbo].[CateringChoices] OFF

SET IDENTITY_INSERT [dbo].[EquipmentChoices] ON
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (1, '2013-05-15 12:00:00', '2013-05-15 15:00:00', 1,1)
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (2, '2013-06-10 10:00:00', '2013-06-10 13:00:00', 2,2)
INSERT [dbo].[EquipmentChoices] ([ID], [StartTime], [EndTime], [BookingID], [EquipmentID]) VALUES (3, '2013-06-10 14:00:00', '2013-06-10 15:00:00', 3,2)
SET IDENTITY_INSERT [dbo].[EquipmentChoices] OFF