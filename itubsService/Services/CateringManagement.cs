namespace ITubsService.Services
{
    using System.Collections.Generic;

    using ITubsService.Entities;
    using ITubsService.Enums;
    using ITubsService.Interfaces;

    public partial class Service : ICateringManagement
    {
        public RequestStatus GetAllCatering(out IEnumerable<Catering> cateringItems)
        {
            cateringItems = Catering.All;

            return RequestStatus.Success;
        }

        public RequestStatus GetCatering(ref Catering catering)
        {
            catering = Catering.GetCatering(catering.ID);

            return catering != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetCateringChoice(ref CateringChoice cateringChoice)
        {
            cateringChoice = CateringChoice.GetCateringChoice(cateringChoice.ID);

            return cateringChoice != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }
    }

}