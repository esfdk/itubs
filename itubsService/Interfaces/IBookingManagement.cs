namespace ITubsService.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Entities;
    using Enums;

    [ServiceContract]
    public interface IBookingManagement
    {
        [OperationContract]
        RequestStatus GetBooking(string token, ref Booking booking);

        [OperationContract]
        RequestStatus GetAllBookings(string token, DateTime date, out IEnumerable<Booking> bookings);

        [OperationContract]
        RequestStatus CreateBooking(string token, ref Booking newBooking);

        [OperationContract]
        RequestStatus ChangeBooking(string token, ref Booking changedBooking);

        [OperationContract]
        RequestStatus DeleteBooking(string token, int bookingId);

        [OperationContract]
        RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus RemoveCateringFromBooking(string token, CateringChoice cateringChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus AddEquipmentToBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus ChangeTimeOfEquipmentBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus RemoveEquipmentFromBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);
    }
}
