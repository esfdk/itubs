namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Enums;
    using ITubsService.Entities;


    [ServiceContract]
    public interface IPersonManagement
    {
        [OperationContract]
        LoginStatus Login(string username, string password, out Person person);

        [OperationContract]
        RequestStatus Logout(string token);

        [OperationContract]
        RequestStatus GetAllOfUsers(string token, out IEnumerable<Person> people);

        [OperationContract]
        RequestStatus GetUserByEmail(string token, ref Person person);
    }
}
