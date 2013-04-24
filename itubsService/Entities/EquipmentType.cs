using System;
using System.Collections.Generic;

namespace ITubsService.Models
{
    using Entities;

    public partial class EquipmentType
    {
        public EquipmentType()
        {
            this.Equipments = new List<Equipment>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
