// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Catering.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Catering type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Catering
    {
        public Catering()
        {
            CateringChoices = new List<CateringChoice>();
        }

        public static IEnumerable<Catering> All
        {
            get
            {
                return ItubsContext.Db.Caterings.Include("CateringChoice").ToList();
            }
        }

        public int ID { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public System.TimeSpan AvailableFrom { get; set; }
        public System.TimeSpan AvailableTo { get; set; }
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }

        public static Catering GetCatering(int id)
        {
            return All.First(c => c.ID == id);
        }
    }
}
