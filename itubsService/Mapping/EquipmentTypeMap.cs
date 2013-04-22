namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class EquipmentTypeMap : EntityTypeConfiguration<EquipmentType>
    {
        public EquipmentTypeMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Type)
                .IsRequired();

            // Table & Column Mappings
            ToTable("EquipmentTypes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Type).HasColumnName("Type");
        }
    }
}
