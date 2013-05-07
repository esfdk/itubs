namespace Client.Model
{
    using System.Collections.Generic;

    using Client.BookItService;

    public static class BookingModel
    {
        public static Booking GetBooking(int bookingID)
        {
            var b = new Booking { ID = bookingID };

            return ServiceClients.BookingManager.GetBooking(ref b) == RequestStatus.Success ? b : null;
        }

        public static IEnumerable<Booking> GetPendingBookings()
        {
            Booking[] bookings;
            return ServiceClients.BookingManager.GetPendingBookings(out bookings) == RequestStatus.Success ? bookings : null;
        }

        public static IEnumerable<Booking> GetYourBookings()
        {
            Booking[] bookings;

            return ServiceClients.BookingManager.GetBookingsByPerson(out bookings, PersonModel.loggedInUser) == RequestStatus.Success ? bookings : null;
        }

        public static IEnumerable<Booking> GetPersonBookings(int personID)
        {
            Booking[] bookings;

            return ServiceClients.BookingManager.GetBookingsByPerson(out bookings, new Person { ID = personID }) == RequestStatus.Success ? bookings : null;
        }
    }
}