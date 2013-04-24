using System.Data.Entity.ModelConfiguration;
using ITubsService.Entities;
using ITubsService.Models;

namespace ITubsService.Mapping
{
    public class EquipmentChoiceMap : EntityTypeConfiguration<EquipmentChoice>
    {
        public EquipmentChoiceMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("EquipmentChoices");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.StartTime).HasColumnName("StartTime");
            Property(t => t.EndTime).HasColumnName("EndTime");
            Property(t => t.BookingID).HasColumnName("BookingID");
            Property(t => t.EquipmentID).HasColumnName("EquipmentID");

            // Relationships
            HasRequired(t => t.Booking)
                .WithMany(t => t.EquipmentChoices)
                .HasForeignKey(d => d.BookingID);
            HasRequired(t => t.Equipment)
                .WithMany(t => t.EquipmentChoices)
                .HasForeignKey(d => d.EquipmentID);

        }
    }
}
