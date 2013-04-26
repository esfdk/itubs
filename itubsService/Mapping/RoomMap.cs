using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ITubsService.Models.Mapping
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Rooms");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MaxParticipants).HasColumnName("MaxParticipants");
        }
    }
}
