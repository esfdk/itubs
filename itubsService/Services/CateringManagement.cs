using ITubsService.Entities;

namespace ITubsService.Services
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public partial class Service : ICateringManagement
    {
        public RequestStatus GetAllCatering(out IEnumerable<Catering> cateringItems)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetCatering(ref Catering catering)
        {
            throw new System.NotImplementedException();
        }

        public RequestStatus GetCateringChoice(string token, ref CateringChoice cateringChoice)
        {
            throw new System.NotImplementedException();
        }
    }

}