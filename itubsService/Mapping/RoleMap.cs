namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RoleName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Roles");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
