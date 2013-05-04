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
        #region Administrator Access


        public const string AdminPassword = "zAq12wSx";

        public const string AdminEmail = "Admin@BookIt.dk";

        public const string AdminRole = "Administrator";

        #endregion

        #region LDAP server

        public const string LDAPServer = "192.168.30.244";

        // TODO: Use actual user
        public const string NetworkUsername = "";

        public const string NetworkPassword = "";

        #endregion

        #region Booking Variables

        public readonly static DateTime EarliestBooking = new DateTime(0, 0, 0, 9, 0, 0);

        public readonly static DateTime LatestBooking = new DateTime(0, 0, 0, 21, 0, 0);

        #endregion

        #region Catering Variables

        public readonly static int CateringLimit = 10;

        public readonly static int DaysToPrepareBigCatering = 10;

        public readonly static int DaysToPrepareSmallCatering = 2;

        #endregion

        public static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Available") || status.Equals("Repair") || status.Equals("Booked"));
        }
    }
}