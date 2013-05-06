namespace Client.Model
{
    using Client.BookItService;

    public class BookingModel
    {
        public static Booking GetBooking(int bookingID)
        {
            var b = new Booking { ID = bookingID };

            return ServiceClients.BookingManager.GetBooking(ref b) == RequestStatus.Success ? b : null;
        }
    }
}