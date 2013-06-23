namespace Client.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Client.BookItService;
    using Client.Types;

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

        /// <summary>Creates or updates a booking.</summary>
        /// <param name="booking">The booking to create/update.</param>
        /// <param name="wasAChange">If the call changed a booking instead of creating a new one, this will be true.</param>
        /// <returns>The result of the method call.</returns>
        public static RequestResult CreateOrUpdateBooking(Booking booking, out bool wasAChange)
        {
            wasAChange = false;
            Booking[] bookings;

            var result = ServiceClients.BookingManager.GetBookingsByDate(out bookings, booking.StartTime.Date);

            if (result != RequestStatus.Success) return RequestResult.InvalidInput;

            var temp = bookings.FirstOrDefault(b => BookingsOverlap(b, booking));

            RequestStatus rs;
            if (temp == null) rs = ServiceClients.BookingManager.CreateBooking(PersonModel.loggedInUser.Token, ref booking);
            else
            {
                temp.StartTime = booking.StartTime;
                temp.EndTime = booking.EndTime;
                rs = ServiceClients.BookingManager.ChangeTimeOfBooking(PersonModel.loggedInUser.Token, ref temp);
                wasAChange = true;
            }

            switch (rs)
            {
                case RequestStatus.Success: return RequestResult.Success;
                case RequestStatus.AccessDenied: return RequestResult.AccessDenied;
                case RequestStatus.InvalidInput: return RequestResult.InvalidInput;
                default: return RequestResult.Error;
            }
        }

        public static RequestResult DeleteBooking(int bookingID)
        {
            switch (ServiceClients.BookingManager.DeleteBooking(PersonModel.loggedInUser.Token, bookingID))
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                case RequestStatus.AccessDenied:
                    return RequestResult.AccessDenied;
                case RequestStatus.InvalidInput:
                    return RequestResult.InvalidInput;
                default:
                    return RequestResult.Error;
            }
        }

        public static RequestResult DeleteCateringChoice(int ccID)
        {
            Booking b;
            var cc = new CateringChoice { ID = ccID };
            switch (ServiceClients.BookingManager.RemoveCateringChoice(out b, PersonModel.loggedInUser.Token, cc))
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                default:
                    return RequestResult.Error;
            }
        }

        public static RequestResult UpdateTimeOfCateringChoice(int ccID, DateTime time)
        {
            Booking b;
            var cc = new CateringChoice { ID = ccID };
            switch (ServiceClients.BookingManager.ChangeTimeOfCateringChoice(out b, PersonModel.loggedInUser.Token, cc))
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                default:
                    return RequestResult.Error;
            }
        }

        public static RequestResult CreateCateringChoice(int bookingID, int cateringID, int amount, DateTime time)
        {
            Booking b;
            var cc = new CateringChoice { CateringID = cateringID, BookingID = bookingID, Amount = amount, Time = time };
            switch (ServiceClients.BookingManager.AddCateringToBooking(out b, PersonModel.loggedInUser.Token, cc))
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                case RequestStatus.AccessDenied:
                    return RequestResult.AccessDenied;
                case RequestStatus.InvalidInput:
                    return RequestResult.InvalidInput;
                default:
                    return RequestResult.Error;
            }
        }

        public static RequestResult ChangeStatus(Booking b)
        {
            var rs = ServiceClients.BookingManager.ChangeBookingStatus(PersonModel.loggedInUser.Token, ref b);

            switch (rs)
            {
                case RequestStatus.Success:
                    return RequestResult.Success;
                case RequestStatus.AccessDenied:
                    return RequestResult.AccessDenied;
                case RequestStatus.InvalidInput:
                    return RequestResult.InvalidInput;
                default:
                    return RequestResult.Error;
            }
        }

        /// <summary>Checks if any bookings overlap.</summary>
        /// <param name="b1">Booking 1 to compare.</param>
        /// <param name="b2">Booking 2 to compare.</param>
        /// <returns>If any bookings overlap.</returns>
        private static bool BookingsOverlap(Booking b1, Booking b2)
        {
            return b1.RoomID == b2.RoomID
                   &&
                   ((b1.StartTime <= b2.StartTime && b1.EndTime > b2.StartTime)        /* Starting before or same time as booking & ends after start time of booking. */
                   || (b1.StartTime >= b2.StartTime && b1.EndTime <= b2.EndTime)      /* Starting after or same time as booking & ends after or same time as booking. */
                   || (b1.StartTime <= b2.StartTime && b1.EndTime >= b2.EndTime)      /* Starting before or same time as booking & ends same time or after booking. */
                   || (b1.StartTime >= b2.StartTime && b1.StartTime < b2.EndTime));   /* Starting after or same time as booking & starting before end time of booking. */
        }
    }
}