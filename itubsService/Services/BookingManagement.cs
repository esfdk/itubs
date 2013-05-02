namespace ITubsService.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Entities;
    using Enums;
    using Interfaces;

    public partial class Service : IBookingManagement
    {
        public RequestStatus GetBooking(ref Booking booking)
        {
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
            bookings = Booking.GetAllBookings(person);
            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus CreateBooking(string token, ref Booking newBooking)
        {
            var p = Person.GetByToken(token);
            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) && p.ID != newBooking.PersonID)
            {
                return RequestStatus.AccessDenied;
            }

            newBooking = Booking.CreateNewBooking(newBooking);
            return newBooking != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeTimeOfBooking(string token, ref Booking changedBooking)
        {
            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(changedBooking.ID);

            if (p == null || booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) && p.ID != booking.PersonID)
            {
                return RequestStatus.AccessDenied;
            }

            var rs = booking.ChangeTime(changedBooking);
            changedBooking = booking;
            return rs;
        }

        public RequestStatus ChangeBookingStatus(string token, ref Booking changedBooking)
        {
            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(changedBooking.ID);

            if (p == null || booking == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)))
            {
                return RequestStatus.AccessDenied;
            }

            var rs = booking.ChangeStatus(changedBooking);
            changedBooking = booking;
            return rs;
        }

        public RequestStatus DeleteBooking(string token, int bookingId)
        {
            var p = Person.GetByToken(token);
            var booking = Booking.GetBookingByID(bookingId);
            if (booking == null || p == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) && p.ID != booking.PersonID)
            {
                return RequestStatus.AccessDenied;
            }

            return booking.Remove();
        }

        public RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            editedBooking = null;
            var p = Person.GetByToken(token);
            var b = Booking.GetBookingByID(cateringChoice.BookingID);

            if (p == null || b == null)
            {
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) && p.ID != b.PersonID)
            {
                return RequestStatus.AccessDenied;
            }

            editedBooking = Booking.GetBookingByID(cateringChoice.BookingID);
            return editedBooking.AddCatering(cateringChoice);
        }

        public RequestStatus RemoveCateringChoice(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            var p = Person.GetByToken(token);
            var cc = CateringChoice.GetCateringChoice(cateringChoice.ID);
            if (cc == null)
            {
                editedBooking = null;
                return RequestStatus.InvalidInput;
            }

            if (!p.Roles.Any(r => r.RoleName.Equals(Configuration.AdminRole)) || p.ID != cc.Booking.PersonID)
            {
                editedBooking = null;
                return RequestStatus.AccessDenied;
            }

            var rs = cc.Remove();
            editedBooking = Booking.GetBookingByID(cateringChoice.ID);
            return rs;
        }

        public RequestStatus AddEquipmentToBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
            return editedBooking != null ? editedBooking.AddEquipment(equipmentChoice) : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeTimeOfEquipmentBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            var ec = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);
            editedBooking = null;
            if (ec != null)
            {
                var rs = ec.ChangeTime(equipmentChoice);
                editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
                return rs;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveEquipmentChoice(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            var ec = EquipmentChoice.GetEquipmentChoiceByID(equipmentChoice.ID);
            if (ec == null)
            {
                editedBooking = null;
                return RequestStatus.InvalidInput;
            }

            var rs = ec.Remove();
            editedBooking = Booking.GetBookingByID(equipmentChoice.BookingID);
            return rs;
        }
    }
}