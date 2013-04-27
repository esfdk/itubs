namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    public class BookingMap : EntityTypeConfiguration<Booking>
    {
        public BookingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Status)
                .IsRequired();

            this.Property(t => t.Comments)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Bookings");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.NumberOfParticipants).HasColumnName("NumberOfParticipants");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.RoomID).HasColumnName("RoomID");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.Bookings)
                .HasForeignKey(d => d.PersonID);
            this.HasRequired(t => t.Room)
                .WithMany(t => t.Bookings)
                .HasForeignKey(d => d.RoomID);

        }
    }
}
