using System;
using ITubsService.Models;

namespace ITubsService.Entities
{
    public class EquipmentChoice
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BookingID { get; set; }
        public int EquipmentID { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
