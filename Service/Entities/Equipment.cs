namespace BookITService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using BookITService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(EquipmentChoice))]
    [KnownType(typeof(EquipmentType))]
    public class Equipment
    {
        public Equipment()
        {
            this.EquipmentChoices = new List<EquipmentChoice>();
        }

        public static IEnumerable<Equipment> All
        {
            get
            {
                return BookITContext.Db.Equipments.Include("EquipmentChoices").Include("EquipmentType").ToList();
            }
        }

        public static Equipment GetEquipmentByID(int id)
        {
            return All.FirstOrDefault(r => r.ID == id);
        }

        public static Equipment NewEquipment(Equipment newEquipment)
        {
            if (Configuration.IsAStatus(newEquipment.Status) && EquipmentType.All.Any(et => et.ID == newEquipment.EquipmentTypeID))
            {
                BookITContext.Db.Equipments.Add(
                    new Equipment
                        {
                            ProductName = newEquipment.ProductName,
                            Status = newEquipment.Status,
                            EquipmentType = EquipmentType.All.FirstOrDefault(et => et.ID == newEquipment.EquipmentTypeID),
                            EquipmentTypeID = newEquipment.EquipmentTypeID
                        });
                BookITContext.Db.SaveChanges();
            }
            else
            {
                return null;
            }

            return
                All.FirstOrDefault(
                    e =>
                    e.EquipmentTypeID == newEquipment.EquipmentTypeID && e.ProductName.Equals(newEquipment.ProductName)
                    && e.Status.Equals(newEquipment.Status));
        }

        public RequestStatus Edit(Equipment updatedEquipment)
        {
            if (updatedEquipment == null)
            {
                return RequestStatus.InvalidInput;
            }

            this.EquipmentTypeID = updatedEquipment.EquipmentTypeID > 0
                                       ? updatedEquipment.EquipmentTypeID
                                       : this.EquipmentTypeID;
            this.ProductName = !string.IsNullOrWhiteSpace(updatedEquipment.ProductName)
                                   ? updatedEquipment.ProductName
                                   : this.ProductName;
            this.Status = Configuration.IsAStatus(updatedEquipment.Status)
                              ? updatedEquipment.Status
                              : this.Status;

            BookITContext.Db.SaveChanges();

            return RequestStatus.Success;
        }

        public RequestStatus Remove()
        {
            BookITContext.Db.Equipments.Remove(this);
            BookITContext.Db.SaveChanges();
            return RequestStatus.Success;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int EquipmentTypeID { get; set; }
        [DataMember]
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        [DataMember]
        public virtual EquipmentType EquipmentType { get; set; }
    }
}
