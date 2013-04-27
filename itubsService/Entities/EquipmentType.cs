namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentType
    {
        public EquipmentType()
        {
            Equipments = new List<Equipment>();
        }

        public static IEnumerable<EquipmentType> All
        {
            get
            {
                return ItubsContext.Db.EquipmentTypes.Include("Equipments").ToList();
            }
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
