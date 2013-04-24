// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomMap.cs" company="">
//   
// </copyright>
// <summary>
//   The room map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    using Models;

    /// <summary>
    /// The room map.
    /// </summary>
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomMap"/> class.
        /// </summary>
        public RoomMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Rooms");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.MaxParticipants).HasColumnName("MaxParticipants");
        }
    }
}
