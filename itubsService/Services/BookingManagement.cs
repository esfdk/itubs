namespace ITubsService.Services
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
            booking = Booking.GetBookingByID(booking.ID);
            return booking != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetBookingsByDate(DateTime date, out IEnumerable<Booking> bookings)
        {
            bookings = Booking.GetBookingsByDate(date);
            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus GetAllBookings(Person person, out IEnumerable<Booking> bookings)
        {
            bookings = Booking.GetAllBookings(person);
            return bookings != null ? RequestStatus.Success : RequestStatus.Error;
        }

        public RequestStatus CreateBooking(string token, ref Booking newBooking)
        {
            newBooking = Booking.CreateNewBooking(newBooking);
            return newBooking != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeTimeOfBooking(string token, ref Booking changedBooking)
        {
            var booking = Booking.GetBookingByID(changedBooking.ID);
            return booking != null ? booking.ChangeTime(changedBooking) : RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeBookingStatus(string token, ref Booking changedBooking)
        {
            var booking = Booking.GetBookingByID(changedBooking.ID);
            return booking != null ? booking.ChangeStatus(changedBooking) : RequestStatus.InvalidInput;
        }

        public RequestStatus DeleteBooking(string token, int bookingId)
        {
            var booking = Booking.GetBookingByID(bookingId);
            return booking != null ? booking.Remove() : RequestStatus.InvalidInput;
        }

        public RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            editedBooking = Booking.GetBookingByID(cateringChoice.BookingID);
            return editedBooking != null ? editedBooking.AddCatering(cateringChoice) : RequestStatus.InvalidInput;
        }

        public RequestStatus RemoveCateringChoice(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            var cc = CateringChoice.GetCateringChoice(cateringChoice.ID);
            if (cc == null)
            {
                editedBooking = null;
                return RequestStatus.InvalidInput;
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
            throw new NotImplementedException();
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