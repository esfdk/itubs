using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ITubsService.Models.Mapping
{
    public class InventoryTypeMap : EntityTypeConfiguration<InventoryType>
    {
        public InventoryTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("InventoryTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
