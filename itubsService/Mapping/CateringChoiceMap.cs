using ITubsService.Entities;

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class CateringChoiceMap : EntityTypeConfiguration<CateringChoice>
    {
        public CateringChoiceMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            ToTable("CateringChoices");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Amount).HasColumnName("Amount");
            Property(t => t.Time).HasColumnName("Time");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.BookingID).HasColumnName("BookingID");
            Property(t => t.CateringID).HasColumnName("CateringID");

            // Relationships
            HasRequired(t => t.Booking)
                .WithMany(t => t.CateringChoices)
                .HasForeignKey(d => d.BookingID);
            HasRequired(t => t.Catering)
                .WithMany(t => t.CateringChoices)
                .HasForeignKey(d => d.CateringID);
        }
    }
}
