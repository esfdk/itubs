using ITubsService.Entities;

namespace ITubsService.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Enums;

    [ServiceContract]
    interface ICateringManagement
    {
        [OperationContract]
        RequestStatus GetAllCatering(out IEnumerable<Catering> cateringItems);

        [OperationContract]
        RequestStatus GetCatering(ref Catering catering);

        [OperationContract]
        RequestStatus GetCateringChoice(ref CateringChoice cateringChoice);
    }
}
