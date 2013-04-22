namespace ITubsService.Entities
{
    using Models;

    public class CateringChoice
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public System.DateTime Time { get; set; }
        public string Status { get; set; }
        public int BookingID { get; set; }
        public int CateringID { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Catering Catering { get; set; }
    }
}
