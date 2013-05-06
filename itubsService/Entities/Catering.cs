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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    [KnownType(typeof(CateringChoice))]
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
                return ItubsContext.Db.Caterings.Include("CateringChoices").ToList();
            }
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public TimeSpan AvailableFrom { get; set; }
        [DataMember]
        public TimeSpan AvailableTo { get; set; }
        [DataMember]
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }

        public static Catering GetCatering(int id)
        {
            return All.First(c => c.ID == id);
        }

        public static bool IsAvailable(int cateringID, DateTime time)
        {
            var c = All.FirstOrDefault(ca => ca.ID == cateringID);
            return c != null && time.Hour >= c.AvailableFrom.Hours && time.Hour <= c.AvailableTo.Hours;
        }
    }
}
