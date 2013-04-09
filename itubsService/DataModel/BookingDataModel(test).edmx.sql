-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 04/09/2013 14:13:23
-- Generated from EDMX file: C:\Users\Jakob Melnyk\Documents\GitHub\itubs\itubsService\DataModel\BookingDataModel.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------

DROP DATABASE IF EXISTS `itubst`;
CREATE DATABASE `itubst`;
USE `itubst`;

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `Inventories` DROP CONSTRAINT `FK_InventoryTypeInventory`;
--    ALTER TABLE `RoomInventories` DROP CONSTRAINT `FK_InventoryRoomInventory`;
--    ALTER TABLE `RoomInventories` DROP CONSTRAINT `FK_RoomRoomInventory`;
--    ALTER TABLE `EquipmentChoices` DROP CONSTRAINT `FK_EquipmentEquipmentChoice`;
--    ALTER TABLE `CateringChoices` DROP CONSTRAINT `FK_CateringCateringChoice`;
--    ALTER TABLE `CateringChoices` DROP CONSTRAINT `FK_BookingCateringChoice`;
--    ALTER TABLE `Equipments` DROP CONSTRAINT `FK_EquipmentTypeEquipment`;
--    ALTER TABLE `Caterings` DROP CONSTRAINT `FK_CateringTypeCatering`;
--    ALTER TABLE `Bookings` DROP CONSTRAINT `FK_EquipmentChoiceBooking`;
--    ALTER TABLE `Bookings` DROP CONSTRAINT `FK_RoomBooking`;
--    ALTER TABLE `People` DROP CONSTRAINT `FK_PersonRole`;
--    ALTER TABLE `Bookings` DROP CONSTRAINT `FK_PersonBooking`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `People`;
    DROP TABLE IF EXISTS `Roles`;
    DROP TABLE IF EXISTS `Bookings`;
    DROP TABLE IF EXISTS `Inventories`;
    DROP TABLE IF EXISTS `Caterings`;
    DROP TABLE IF EXISTS `Equipments`;
    DROP TABLE IF EXISTS `CateringChoices`;
    DROP TABLE IF EXISTS `Rooms`;
    DROP TABLE IF EXISTS `RoomInventories`;
    DROP TABLE IF EXISTS `EquipmentChoices`;
    DROP TABLE IF EXISTS `EquipmentTypes`;
    DROP TABLE IF EXISTS `InventoryTypes`;
    DROP TABLE IF EXISTS `CateringTypes`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

CREATE TABLE `People`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` varchar (1000) NOT NULL, 
	`Email` varchar (1000) NOT NULL, 
	`Role_Id` int NOT NULL);

ALTER TABLE `People` ADD PRIMARY KEY (Id);




CREATE TABLE `Roles`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`RoleName` varchar (1000) NOT NULL);

ALTER TABLE `Roles` ADD PRIMARY KEY (Id);




CREATE TABLE `Bookings`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Status` varchar (1000) NOT NULL, 
	`NumberOfParticipants` varchar (1000) NOT NULL, 
	`Comments` varchar (1000) NOT NULL, 
	`EquipmentChoiceId` int NOT NULL, 
	`RoomId` int NOT NULL, 
	`PersonId` int NOT NULL);

ALTER TABLE `Bookings` ADD PRIMARY KEY (Id);




CREATE TABLE `Inventories`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`iProductName` varchar (1000) NOT NULL, 
	`Status` varchar (1000) NOT NULL, 
	`InventoryTypeId` int NOT NULL);

ALTER TABLE `Inventories` ADD PRIMARY KEY (Id);




CREATE TABLE `Caterings`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Price` varchar (1000) NOT NULL, 
	`cProductName` varchar (1000) NOT NULL, 
	`CateringTypeId` int NOT NULL);

ALTER TABLE `Caterings` ADD PRIMARY KEY (Id);




CREATE TABLE `Equipments`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`eProductName` varchar (1000) NOT NULL, 
	`EquipmentTypeId` int NOT NULL);

ALTER TABLE `Equipments` ADD PRIMARY KEY (Id);




CREATE TABLE `CateringChoices`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Number` varchar (1000) NOT NULL, 
	`Time` varchar (1000) NOT NULL, 
	`BookingId` int NOT NULL, 
	`Catering_Id` int NOT NULL);

ALTER TABLE `CateringChoices` ADD PRIMARY KEY (Id);




CREATE TABLE `Rooms`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Name` varchar (1000) NOT NULL, 
	`Size` varchar (1000) NOT NULL, 
	`Price` varchar (1000) NOT NULL);

ALTER TABLE `Rooms` ADD PRIMARY KEY (Id);




CREATE TABLE `RoomInventories`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Number` varchar (1000) NOT NULL, 
	`InventoryId` int NOT NULL, 
	`RoomId` int NOT NULL);

ALTER TABLE `RoomInventories` ADD PRIMARY KEY (Id);




CREATE TABLE `EquipmentChoices`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`StartTime` varchar (1000) NOT NULL, 
	`EndTime` varchar (1000) NOT NULL, 
	`Equipment_Id` int NOT NULL);

ALTER TABLE `EquipmentChoices` ADD PRIMARY KEY (Id);




CREATE TABLE `EquipmentTypes`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`eType` varchar (1000) NOT NULL);

ALTER TABLE `EquipmentTypes` ADD PRIMARY KEY (Id);




CREATE TABLE `InventoryTypes`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`iType` varchar (1000) NOT NULL);

ALTER TABLE `InventoryTypes` ADD PRIMARY KEY (Id);




CREATE TABLE `CateringTypes`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`cType` varchar (1000) NOT NULL);

ALTER TABLE `CateringTypes` ADD PRIMARY KEY (Id);






-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `InventoryTypeId` in table 'Inventories'

ALTER TABLE `Inventories`
ADD CONSTRAINT `FK_InventoryTypeInventory`
    FOREIGN KEY (`InventoryTypeId`)
    REFERENCES `InventoryTypes`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryTypeInventory'

CREATE INDEX `IX_FK_InventoryTypeInventory` 
    ON `Inventories`
    (`InventoryTypeId`);

-- Creating foreign key on `InventoryId` in table 'RoomInventories'

ALTER TABLE `RoomInventories`
ADD CONSTRAINT `FK_InventoryRoomInventory`
    FOREIGN KEY (`InventoryId`)
    REFERENCES `Inventories`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryRoomInventory'

CREATE INDEX `IX_FK_InventoryRoomInventory` 
    ON `RoomInventories`
    (`InventoryId`);

-- Creating foreign key on `RoomId` in table 'RoomInventories'

ALTER TABLE `RoomInventories`
ADD CONSTRAINT `FK_RoomRoomInventory`
    FOREIGN KEY (`RoomId`)
    REFERENCES `Rooms`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomRoomInventory'

CREATE INDEX `IX_FK_RoomRoomInventory` 
    ON `RoomInventories`
    (`RoomId`);

-- Creating foreign key on `Equipment_Id` in table 'EquipmentChoices'

ALTER TABLE `EquipmentChoices`
ADD CONSTRAINT `FK_EquipmentEquipmentChoice`
    FOREIGN KEY (`Equipment_Id`)
    REFERENCES `Equipments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentChoice'

CREATE INDEX `IX_FK_EquipmentEquipmentChoice` 
    ON `EquipmentChoices`
    (`Equipment_Id`);

-- Creating foreign key on `Catering_Id` in table 'CateringChoices'

ALTER TABLE `CateringChoices`
ADD CONSTRAINT `FK_CateringCateringChoice`
    FOREIGN KEY (`Catering_Id`)
    REFERENCES `Caterings`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringCateringChoice'

CREATE INDEX `IX_FK_CateringCateringChoice` 
    ON `CateringChoices`
    (`Catering_Id`);

-- Creating foreign key on `BookingId` in table 'CateringChoices'

ALTER TABLE `CateringChoices`
ADD CONSTRAINT `FK_BookingCateringChoice`
    FOREIGN KEY (`BookingId`)
    REFERENCES `Bookings`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingCateringChoice'

CREATE INDEX `IX_FK_BookingCateringChoice` 
    ON `CateringChoices`
    (`BookingId`);

-- Creating foreign key on `EquipmentTypeId` in table 'Equipments'

ALTER TABLE `Equipments`
ADD CONSTRAINT `FK_EquipmentTypeEquipment`
    FOREIGN KEY (`EquipmentTypeId`)
    REFERENCES `EquipmentTypes`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentTypeEquipment'

CREATE INDEX `IX_FK_EquipmentTypeEquipment` 
    ON `Equipments`
    (`EquipmentTypeId`);

-- Creating foreign key on `CateringTypeId` in table 'Caterings'

ALTER TABLE `Caterings`
ADD CONSTRAINT `FK_CateringTypeCatering`
    FOREIGN KEY (`CateringTypeId`)
    REFERENCES `CateringTypes`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CateringTypeCatering'

CREATE INDEX `IX_FK_CateringTypeCatering` 
    ON `Caterings`
    (`CateringTypeId`);

-- Creating foreign key on `EquipmentChoiceId` in table 'Bookings'

ALTER TABLE `Bookings`
ADD CONSTRAINT `FK_EquipmentChoiceBooking`
    FOREIGN KEY (`EquipmentChoiceId`)
    REFERENCES `EquipmentChoices`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentChoiceBooking'

CREATE INDEX `IX_FK_EquipmentChoiceBooking` 
    ON `Bookings`
    (`EquipmentChoiceId`);

-- Creating foreign key on `RoomId` in table 'Bookings'

ALTER TABLE `Bookings`
ADD CONSTRAINT `FK_RoomBooking`
    FOREIGN KEY (`RoomId`)
    REFERENCES `Rooms`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomBooking'

CREATE INDEX `IX_FK_RoomBooking` 
    ON `Bookings`
    (`RoomId`);

-- Creating foreign key on `Role_Id` in table 'People'

ALTER TABLE `People`
ADD CONSTRAINT `FK_PersonRole`
    FOREIGN KEY (`Role_Id`)
    REFERENCES `Roles`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRole'

CREATE INDEX `IX_FK_PersonRole` 
    ON `People`
    (`Role_Id`);

-- Creating foreign key on `PersonId` in table 'Bookings'

ALTER TABLE `Bookings`
ADD CONSTRAINT `FK_PersonBooking`
    FOREIGN KEY (`PersonId`)
    REFERENCES `People`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonBooking'

CREATE INDEX `IX_FK_PersonBooking` 
    ON `Bookings`
    (`PersonId`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
