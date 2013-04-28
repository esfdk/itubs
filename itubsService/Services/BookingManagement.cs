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
            throw new NotImplementedException();
        }

        public RequestStatus ChangeBooking(string token, ref Booking changedBooking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteBooking(string token, int bookingId)
        {
            throw new NotImplementedException();
        }

        public RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus RemoveCateringFromBooking(string token, CateringChoice cateringChoice, out Booking editedBooking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus AddEquipmentToBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus ChangeTimeOfEquipmentBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus RemoveEquipmentFromBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking)
        {
            throw new NotImplementedException();
        }
    }

}