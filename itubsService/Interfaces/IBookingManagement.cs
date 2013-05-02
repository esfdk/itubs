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
        RequestStatus GetBooking(ref Booking booking);

        [OperationContract]
        RequestStatus GetBookingsByDate(DateTime date, out IEnumerable<Booking> bookings);

        [OperationContract]
        RequestStatus GetBookingsByPerson(Person person, out IEnumerable<Booking> bookings);

        [OperationContract]
        RequestStatus CreateBooking(string token, ref Booking newBooking);

        [OperationContract]
        RequestStatus ChangeTimeOfBooking(string token, ref Booking changedBooking);

        [OperationContract]
        RequestStatus ChangeBookingStatus(string token, ref Booking changedBooking);

        [OperationContract]
        RequestStatus DeleteBooking(string token, int bookingId);

        [OperationContract]
        RequestStatus AddCateringToBooking(string token, CateringChoice cateringChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus RemoveCateringChoice(string token, CateringChoice cateringChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus AddEquipmentToBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus ChangeTimeOfEquipmentBooking(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);

        [OperationContract]
        RequestStatus RemoveEquipmentChoice(string token, EquipmentChoice equipmentChoice, out Booking editedBooking);
    }
}
