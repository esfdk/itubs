namespace BookITService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using BookITService.Entities;


    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired();

            this.Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Inventories");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.InventoryTypeID).HasColumnName("InventoryTypeID");
            this.Property(t => t.RoomID).HasColumnName("RoomID");

            // Relationships
            this.HasRequired(t => t.InventoryType)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.InventoryTypeID);
            this.HasOptional(t => t.Room)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.RoomID);

        }
    }
}
