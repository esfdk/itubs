
namespace Client.Model
{
    using System.Collections.Generic;

    using Client.BookItService;

    public class CateringModel
    {
        public static IEnumerable<Catering> GetAllCaterings()
        {
            Catering[] cateringEnumerable;

            var ret = ServiceClients.CateringManager.GetAllCatering(out cateringEnumerable) == RequestStatus.Success ? cateringEnumerable : null;

            return ret;
        }
    }
}