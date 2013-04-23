namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Entities;
    using Enums;


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
        RequestStatus GetByEmail(string token, ref Person person);

        [OperationContract]
        RequestStatus GetByToken(string token, out Person person);
    }
}
