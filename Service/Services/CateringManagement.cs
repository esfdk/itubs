namespace BookITService.Services
{
    using System.Collections.Generic;

    using BookITService.Entities;
    using BookITService.Enums;
    using BookITService.Interfaces;

    public partial class Service : ICateringManagement
    {
        public RequestStatus GetAllCatering(out IEnumerable<Catering> cateringItems)
        {
            cateringItems = Catering.All;
            return cateringItems != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetCatering(ref Catering catering)
        {
            if (catering == null)
            {
                return RequestStatus.InvalidInput;
            }

            catering = Catering.GetCatering(catering.ID);

            return catering != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }

        public RequestStatus GetCateringChoice(ref CateringChoice cateringChoice)
        {
            if (cateringChoice == null)
            {
                return RequestStatus.InvalidInput;
            }

            cateringChoice = CateringChoice.GetCateringChoice(cateringChoice.ID);

            return cateringChoice != null ? RequestStatus.Success : RequestStatus.InvalidInput;
        }
    }
}