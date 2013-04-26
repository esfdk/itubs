using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ITubsService.Models.Mapping
{
    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired();

            this.Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Equipments");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.EquipmentTypeID).HasColumnName("EquipmentTypeID");

            // Relationships
            this.HasRequired(t => t.EquipmentType)
                .WithMany(t => t.Equipments)
                .HasForeignKey(d => d.EquipmentTypeID);

        }
    }
}
