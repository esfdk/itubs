namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Equipment))]
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

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
