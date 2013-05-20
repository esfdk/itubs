namespace Client.Model
{
    using Client.BookItService;
    using Client.Types;

    public static class PersonModel
    {
        public static Person loggedInUser { get; private set; }

        public static RequestResult Login(string username, string password)
        {
            Person p;
            switch (ServiceClients.PersonManager.Login(out p, username, password))
            {
                case LoginStatus.Success:
                    loggedInUser = p;
                    return RequestResult.Success;

                case LoginStatus.CommunicationFailure:
                    return RequestResult.CommunicationFailure;

                case LoginStatus.WrongUserNameOrPassword:
                    return RequestResult.WrongUserNameOrPassword;

                case LoginStatus.InvalidInput:
                    return RequestResult.InvalidInput;

                default:
                    return RequestResult.Error;
            }
        }

        public static RequestResult Logout()
        {
            switch (ServiceClients.PersonManager.Logout(loggedInUser.Token))
            {
                case RequestStatus.Success:
                    loggedInUser = null;
                    return RequestResult.Success;

                default:
                    return RequestResult.Error;
            }

        }

        public static Person GetPersonByMail(string mail)
        {
            var p = new Person { Email = mail };
            return ServiceClients.PersonManager.GetByEmail(loggedInUser.Token, ref p) == RequestStatus.Success ? p : null;
        }
    }
}