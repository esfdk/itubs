// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ITubsService
{
    using System;

    public class Configuration
    {

        public const string LDAPServer = "192.168.30.244";

        public const string NetworkUsername = "jmel@itu.dk";

        public const string NetworkPassword = "Esfdk18021991";

        public readonly static DateTime EarliestBooking = new DateTime(0, 0, 0, 9, 0, 0);

        public readonly static DateTime LatestBooking = new DateTime(0, 0, 0, 21, 0, 0);

        public readonly static int CateringLimit = 10;

        public readonly static int DaysToPrepareBigCatering = 10;

        public readonly static int DaysToPrepareSmallCatering = 2;

        public const string AdminRole = "Administrator";

        public static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Available") || status.Equals("Repair") || status.Equals("Booked"));
        }
    }
}