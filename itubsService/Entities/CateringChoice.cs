namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using ITubsService.Enums;

    [DataContract(IsReference = true)]
    [KnownType(typeof(Catering))]
    [KnownType(typeof(Booking))]
    public class CateringChoice
    {
        public static IEnumerable<CateringChoice> All
        {
            get
            {
                return ItubsContext.Db.CateringChoices.ToList();
            }
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public System.DateTime Time { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int BookingID { get; set; }
        [DataMember]
        public int CateringID { get; set; }
        [DataMember]
        public virtual Booking Booking { get; set; }
        [DataMember]
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

        public RequestStatus ChangeTime(CateringChoice updatedCateringChoice)
        {
            if (updatedCateringChoice.Time >= this.Booking.StartTime
                && updatedCateringChoice.Time <= this.Booking.EndTime
                && Catering.IsAvailable(updatedCateringChoice.CateringID, updatedCateringChoice.Time))
            {
                this.Time = updatedCateringChoice.Time;
                ItubsContext.Db.SaveChanges();
                return RequestStatus.Success;
            }

            return RequestStatus.InvalidInput;
        }

        public RequestStatus ChangeStatus(CateringChoice updatedCateringChoice)
        {
            if (!string.IsNullOrWhiteSpace(updatedCateringChoice.Status))
            {
                if (updatedCateringChoice.Status.Equals("Approved"))
                {
                    this.Status = "Approved";
                    ItubsContext.Db.SaveChanges();
                    return RequestStatus.Success;
                }

                return updatedCateringChoice.Status.Equals("Rejected") ? this.Remove() : RequestStatus.InvalidInput;
            }

            return RequestStatus.InvalidInput;
        }
    }
}
