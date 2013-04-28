namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using ITubsService.Enums;

    public class Equipment
    {
        public Equipment()
        {
            EquipmentChoices = new List<EquipmentChoice>();
        }

        public static IEnumerable<Equipment> All
        {
            get
            {
                return ItubsContext.Db.Equipments.Include("EquipmentChoices").ToList();
            }
        }

        public static Equipment GetEquipmentByID(int id)
        {
            return All.FirstOrDefault(r => r.ID == id);
        }

        public static Equipment NewEquipment(Equipment newEquipment)
        {
            if (Configuration.IsAStatus(newEquipment.Status) && !string.IsNullOrWhiteSpace(newEquipment.ProductName) && newEquipment.EquipmentTypeID > 0)
            {
                ItubsContext.Db.Equipments.Add(
                    new Equipment
                        {
                            ProductName = newEquipment.ProductName,
                            Status = newEquipment.Status,
                            EquipmentType = EquipmentType.All.FirstOrDefault(et => et.ID == newEquipment.EquipmentTypeID),
                            EquipmentTypeID = newEquipment.EquipmentTypeID
                        });
                ItubsContext.Db.SaveChanges();
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

            ItubsContext.Db.SaveChanges();

            return RequestStatus.Success;
        }

        public void Remove()
        {
            ItubsContext.Db.Equipments.Remove(this);
            ItubsContext.Db.SaveChanges();
        }

        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public int EquipmentTypeID { get; set; }
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
    }
}
