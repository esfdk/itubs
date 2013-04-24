using ITubsService.Entities;

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class BookingMap : EntityTypeConfiguration<Booking>
    {
        public BookingMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Status)
                .IsRequired();

            Property(t => t.Comments)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Bookings");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.NumberOfParticipants).HasColumnName("NumberOfParticipants");
            Property(t => t.Comments).HasColumnName("Comments");
            Property(t => t.StartTime).HasColumnName("StartTime");
            Property(t => t.EndTime).HasColumnName("EndTime");
            Property(t => t.PersonID).HasColumnName("PersonID");
            Property(t => t.RoomID).HasColumnName("RoomID");

            // Relationships
            HasRequired(t => t.Person)
                .WithMany(t => t.Bookings)
                .HasForeignKey(d => d.PersonID);
            HasRequired(t => t.Room)
                .WithMany(t => t.Bookings)
                .HasForeignKey(d => d.RoomID);

        }
    }
}
