namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    using Models;

    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ProductName)
                .IsRequired();

            Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Equipments");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.EquipmentTypeID).HasColumnName("EquipmentTypeID");

            // Relationships
            HasRequired(t => t.EquipmentType)
                .WithMany(t => t.Equipments)
                .HasForeignKey(d => d.EquipmentTypeID);
        }
    }
}
