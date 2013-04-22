using ITubsService.Entities;

namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Enums;
    using Models;

    [ServiceContract]
    interface IEquipmentManagement
    {
        [OperationContract]
        RequestStatus CreateNewEquipmentItem(string token, ref Equipment newEquipment);

        [OperationContract]
        RequestStatus ChangeEquipmentItem(string token, ref Equipment equipment);

        [OperationContract]
        RequestStatus DeleteEquipmentItem(string token, int equipmentId);

        [OperationContract]
        RequestStatus GetEquipmentChoice(string token, ref EquipmentChoice equipmentChoice);

        [OperationContract]
        RequestStatus GetEquipmentItem(ref Equipment equipmentItem);

        [OperationContract]
        RequestStatus GetEquipmentTypes(out IEnumerable<string> types);

        [OperationContract]
        RequestStatus GetAllEquipmentItems(string type, IEnumerable<Equipment> items);
    }
}
