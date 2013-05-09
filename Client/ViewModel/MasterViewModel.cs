namespace Client.ViewModel
{
    using System.Linq;

    using Client.Model;

    public static class MasterViewModel
    {
        public static bool LoggedInUserIsAdmin()
        {
            return LoggedInUserID() != -1 && PersonModel.loggedInUser.Roles.Any(r => r.RoleName.Equals("Administrator"));
        }

        public static int LoggedInUserID()
        {
            if (PersonModel.loggedInUser != null)
            {
                return PersonModel.loggedInUser.ID;
            }

            return -1;
        }

        public static string LoggedInUserName()
        {
            if (LoggedInUserID() == -1)
            {
                return null;
            }

            return PersonModel.loggedInUser.Name;
        }
    }
}