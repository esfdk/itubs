// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ITubsService
{
    public class Configuration
    {
        public static string LDAPServer = "192.168.30.244";

        public static string NetworkUsername = "jmel@itu.dk ";

        public static string NetworkPassword = "Esfdk18021991";

        public static bool IsAStatus(string status)
        {
            return !string.IsNullOrWhiteSpace(status) && (status.Equals("Available") || status.Equals("Repair") || status.Equals("Booked"));
        }
    }
}