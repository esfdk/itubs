namespace ITubsService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EquipmentChoice
    {
        public static IEnumerable<EquipmentChoice> All
        {
            get
            {
                return ItubsContext.Db.EquipmentChoices.ToList();
            }
        }

        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BookingID { get; set; }
        public int EquipmentID { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Equipment Equipment { get; set; }

        public static EquipmentChoice GetEquipmentChoiceByID(int id)
        {
            return All.FirstOrDefault(ec => ec.ID == id);
        }
    }
}
