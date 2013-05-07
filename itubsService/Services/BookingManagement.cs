﻿namespace ITubsService.Services
{
    using System;
    using System.Collections.Generic;

    using Entities;
    using Enums;
    using Interfaces;

    public partial class Service : IBookingManagement
    {
        public RequestStatus GetBooking(ref Booking booking)
        {
            if (booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            booking = Booking.GetBookingByID(booking.ID);
            return booking != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetBookingsByDate(DateTime date, out IEnumerable<Booking> bookings)
        {
            bookings = Booking.GetBookingsByDate(date);
            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetBookingsByPerson(Person person, out IEnumerable<Booking> bookings)
        {
            bookings = null;

            if (person == null)
            {
                return RequestStatus.InvalidInput;
            }

            bookings = Booking.GetAllBookings(person);
            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetPendingBookings(out IEnumerable<Booking> bookings)
        {
            bookings = Booking.GetPendingBookings();

            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus CreateBooking(string token, ref Booking newBooking)
        {
            if (string.IsNullOrWhiteSpace(token) || newBooking == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            if (p == null)
            {
                return RequestStatus.AccessDenied;
            }

            if (!p.IsAdmin() && (p.ID != newBooking.PersonID && !newBooking.Status.Equals("Pending")))
            {
                return RequestStatus.AccessDenied;
            }

            newBooking = Booking.CreateNewBooking(newBooking);
            return newBooking != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeTimeOfBooking(string token, ref Booking changedBooking)
        {
            if (string.IsNullOrWhiteSpace(token) || changedBooking == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(changedBooking.ID);
            if (booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = booking.ChangeTime(changedBooking);
            changedBooking = booking;
            return rs;
        }

        public RequestStatus ChangeBookingStatus(string token, ref Booking changedBooking)
        {
            if (string.IsNullOrWhiteSpace(token) || changedBooking == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(changedBooking.ID);
            if (booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || !p.IsAdmin())
            {
                return RequestStatus.AccessDenied;
            }

            var rs = booking.ChangeStatus(changedBooking);
            changedBooking = booking;
            return rs;
        }

        public RequestStatus DeleteBooking(string token, int bookingId)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(bookingId);
            if (booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            return booking.Remove();
        }

        public RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || cateringChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var b = Booking.GetBookingByID(cateringChoice.BookingID);
            if (b == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != b.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            editedBooking = b;
            return editedBooking.AddCatering(cateringChoice);
        }

        public RequestStatus ChangeTimeOfCateringChoice(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || cateringChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var cc = CateringChoice.GetCateringChoice(cateringChoice.ID);
            if (cc == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != cc.Booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = cc.ChangeTime(cateringChoice);
            editedBooking = Booking.GetBookingByID(cateringChoice.BookingID);
            return rs;
        }

        public RequestStatus RemoveCateringChoice(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || cateringChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var cc = CateringChoice.GetCateringChoice(cateringChoice.ID);
            if (cc == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != cc.Booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = cc.Remove();
            editedBooking = Booking.GetBookingByID(cateringChoice.ID);
            return rs;
        }

        public RequestStatus AddEquipmentToBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || equipmentChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var b = Booking.GetBookingByID(equipmentChoice.BookingID);
            if (b == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != b.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
            return editedBooking != null ? editedBooking.AddEquipment(equipmentChoice) : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeTimeOfEquipmentBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || equipmentChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var ec = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);
            if (ec == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != ec.Booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = ec.ChangeTime(equipmentChoice);
            editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
            return rs;
        }

        public RequestStatus RemoveEquipmentChoice(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            editedBooking = null;

            if (string.IsNullOrWhiteSpace(token) || equipmentChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            var p = Person.GetByToken(token);
            var ec = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);
            if (ec == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (p == null || (!p.IsAdmin() && p.ID != ec.Booking.PersonID))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = ec.Remove();
            editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
            return rs;
        }
    }
}