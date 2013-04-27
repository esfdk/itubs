namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    public class EquipmentChoiceMap : EntityTypeConfiguration<EquipmentChoice>
    {
        public EquipmentChoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("EquipmentChoices");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.BookingID).HasColumnName("BookingID");
            this.Property(t => t.EquipmentID).HasColumnName("EquipmentID");

            // Relationships
            this.HasRequired(t => t.Booking)
                .WithMany(t => t.EquipmentChoices)
                .HasForeignKey(d => d.BookingID);
            this.HasRequired(t => t.Equipment)
                .WithMany(t => t.EquipmentChoices)
                .HasForeignKey(d => d.EquipmentID);

        }
    }
}
