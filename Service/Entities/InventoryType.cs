namespace BookITService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;


    [DataContract(IsReference = true)]
    [KnownType(typeof(Inventory))]
    public class InventoryType
    {
        public InventoryType()
        {
            this.Inventories = new List<Inventory>();
        }

        public static IEnumerable<InventoryType> All
        {
            get
            {
                return BookITContext.Db.InventoryTypes.Include("Inventories").ToList();
            }
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
