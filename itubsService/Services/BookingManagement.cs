using System;
using System.Collections.Generic;
using ITubsService.Entities;
using ITubsService.Enums;

namespace ITubsService.Services
{
    using Interfaces;

    public partial class Service : IBookingManagement
    {
        public RequestStatus GetBooking(ref Booking booking)
        {
            throw new NotImplementedException();
        }

        public RequestStatus GetAllBookings(DateTime date, out IEnumerable<Booking> bookings)
        {
            //TODO: Security concern about booking? Should it be possible to retrieve a user by looking at all the bookings
            throw new NotImplementedException();
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