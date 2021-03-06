namespace BookITService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using BookITService.Entities;


    public class EquipmentTypeMap : EntityTypeConfiguration<EquipmentType>
    {
        public EquipmentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EquipmentTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
