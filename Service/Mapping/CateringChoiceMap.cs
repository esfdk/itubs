namespace BookITService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using BookITService.Entities;


    public class CateringChoiceMap : EntityTypeConfiguration<CateringChoice>
    {
        public CateringChoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CateringChoices");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.BookingID).HasColumnName("BookingID");
            this.Property(t => t.CateringID).HasColumnName("CateringID");

            // Relationships
            this.HasRequired(t => t.Booking)
                .WithMany(t => t.CateringChoices)
                .HasForeignKey(d => d.BookingID);
            this.HasRequired(t => t.Catering)
                .WithMany(t => t.CateringChoices)
                .HasForeignKey(d => d.CateringID);

        }
    }
}
