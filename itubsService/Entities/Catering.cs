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

    public class Catering
    {
        public Catering()
        {
            this.CateringChoices = new List<CateringChoice>();
        }

        public int ID { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public System.TimeSpan AvailableFrom { get; set; }
        public System.TimeSpan AvailableTo { get; set; }
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }
    }
}
