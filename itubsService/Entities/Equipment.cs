namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using Models;

    public partial class Equipment
    {
        public Equipment()
        {
            this.EquipmentChoices = new List<EquipmentChoice>();
        }

        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public int EquipmentTypeID { get; set; }
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
    }
}
