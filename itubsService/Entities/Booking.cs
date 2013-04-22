// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Booking.cs" company="">
//   
// </copyright>
// <summary>
//   The booking.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The booking.
    /// </summary>
    [DataContract(IsReference = true)]
    [KnownType(typeof(CateringChoice))]
    [KnownType(typeof(EquipmentChoice))]
    [KnownType(typeof(Person))]
    [KnownType(typeof(Room))]
    public class Booking
    {
        public Booking()
        {
            CateringChoices = new List<CateringChoice>();
            EquipmentChoices = new List<EquipmentChoice>();
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public int NumberOfParticipants { get; set; }
        public string Comments { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int PersonID { get; set; }
        public int RoomID { get; set; }
        public virtual ICollection<CateringChoice> CateringChoices { get; set; }
        public virtual ICollection<EquipmentChoice> EquipmentChoices { get; set; }
        public virtual Person Person { get; set; }
        public virtual Room Room { get; set; }
    }
}
