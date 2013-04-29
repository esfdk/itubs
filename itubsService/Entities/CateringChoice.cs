namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using ITubsService.Enums;

    public class CateringChoice
    {
        public static IEnumerable<CateringChoice> All
        {
            get
            {
                return ItubsContext.Db.CateringChoices.ToList();
            }
        }

        public int ID { get; set; }
        public int Amount { get; set; }
        public System.DateTime Time { get; set; }
        public string Status { get; set; }
        public int BookingID { get; set; }
        public int CateringID { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Catering Catering { get; set; }

        public static CateringChoice GetCateringChoice(int id)
        {
            return All.FirstOrDefault(cc => cc.ID == id);
        }

        public RequestStatus Remove()
        {
            ItubsContext.Db.CateringChoices.Remove(this);
            ItubsContext.Db.SaveChanges();
            return RequestStatus.Success;
        }
    }
}
