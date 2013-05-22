namespace BookITService
{
    using System;

    public static class Configuration
    {
        #region Administrator Access
        /// <summary>Password of admin test user.</summary>
        public static string AdminPassword = "zAq12wSx";

        /// <summary>Email of admin test user.</summary>
        public static string AdminEmail = "Admin@BookIt.dk";

        /// <summary>Role of admin test user.</summary>
        public static string AdminRole = "Administrator";

        #endregion

        #region Test User Access

        /// <summary>Password of test user.</summary>
        public static string TestPassword = "qwerty123";

        /// <summary>Email of test user.</summary>
        public static string TestEmail = "test@bookit.dk";

        #endregion

        #region LDAP server

        /// <summary>The IP of the ADs LDAP server.</summary>
        public static string LDAPServer = "192.168.30.244";

        #endregion

        #region Booking Variables

        /// <summary>The earliest possible booking: 9am.</summary>
        public static DateTime EarliestBooking = new DateTime(1, 1, 1, 9, 0, 0);

        /// <summary>The last possible booking: 9pm.</summary>
        public static DateTime LatestBooking = new DateTime(1, 1, 1, 21, 0, 0);

        #endregion

        #region Catering Variables

        /// <summary>The limit of normal cateringchoice size.</summary>
        public static int CateringLimit = 10;

        /// <summary>The amount of days the cantine needs for a big cateringchoice.</summary>
        public static int DaysToPrepareBigCatering = 10;

        /// <summary>The amount of days the cantine needs for a normal cateringchoice.</summary>
        public static int DaysToPrepareSmallCatering = 2;

        #endregion

        /// <summary>Checks if a status is valid</summary>
        public static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Available") || status.Equals("Repair") || status.Equals("Booked"));
        }
    }
}