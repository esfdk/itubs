namespace BookITService
{
    using System;

    /// <summary>Class containing configuration variables for the service.</summary>
    public static class Configuration
    {
        #region Administrator Access

        public static string AdminPassword = "zAq12wSx";

        public static string AdminEmail = "Admin@BookIt.dk";

        public static string AdminRole = "Administrator";

        #endregion

        #region Test User Access

        public static string TestPassword = "qwerty123";

        public static string TestEmail = "test@bookit.dk";

        #endregion

        #region LDAP server

        public static string LDAPServer = "192.168.30.244";

        #endregion

        #region Booking Variables

        public static DateTime EarliestBooking = new DateTime(1, 1, 1, 9, 0, 0);

        public static DateTime LatestBooking = new DateTime(1, 1, 1, 21, 0, 0);

        #endregion

        #region Catering Variables

        public static int CateringLimit = 10;

        public static int DaysToPrepareBigCatering = 10;

        public static int DaysToPrepareSmallCatering = 2;

        #endregion

        public static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Available") || status.Equals("Repair") || status.Equals("Booked"));
        }
    }
}