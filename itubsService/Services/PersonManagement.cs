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
            person = Person.Login(username, password);

            if (!string.IsNullOrEmpty(person.Token) && !string.IsNullOrEmpty(person.Email) && !string.IsNullOrEmpty(person.Name))
            {
                return LoginStatus.Success;
            }
            if (person.Token == null)
            {
                return LoginStatus.WrongUserNameOrPassword;
            }

            return LoginStatus.InvalidInput;

        }

        public RequestStatus Logout(string token)
        {
            return Person.Logout(token);
        }

        public RequestStatus GetAllOfUsers(string token, out IEnumerable<Person> people)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetUserByEmail(string token, ref Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}