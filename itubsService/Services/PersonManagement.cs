namespace ITubsService.Services
{
    using System.Collections.Generic;

    using Enums;
    using Interfaces;
    using ITubsService.Entities;

    public partial class Service : IPersonManagement
    {
        public LoginStatus Login(string username, string password, out Person person)
        {
            var p = Person.Login(username, password);
            person = null;

            if (p == null)
            {
                return LoginStatus.WrongUserNameOrPassword;
            }

            if (p.ID == -1)
            {
                return LoginStatus.CommunicationFailure;
            }

            if (p.IsAPerson())
            {
                person = p;
                return LoginStatus.Success;
            }

            return LoginStatus.InvalidInput;
        }

        public RequestStatus Logout(string token)
        {
            return Person.Logout(token);
        }

        public RequestStatus GetAllOfUsers(string token, out IEnumerable<Person> people)
        {
            people = Person.All;

            return RequestStatus.Success;
        }

        public RequestStatus GetByEmail(string token, ref Person person)
        {
            person = Person.GetByEMail(person.Email);

            if (person == null)
            {
                return RequestStatus.InvalidInput;
            }

            person.Token = null;
            return RequestStatus.Success;
        }

        public RequestStatus GetByToken(string token, out Person person)
        {
            person = Person.GetByToken(token);

            if (person == null)
            {
                return RequestStatus.InvalidInput;
            }

            return person.IsAPerson() ? RequestStatus.Success : RequestStatus.InvalidInput;
        }
    }
}