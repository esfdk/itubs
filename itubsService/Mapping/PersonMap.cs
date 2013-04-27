namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.Token)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("People");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Token).HasColumnName("Token");

            // Relationships
            this.HasMany(t => t.Roles)
                .WithMany(t => t.People)
                .Map(m =>
                    {
                        m.ToTable("PersonRoles");
                        m.MapLeftKey("PersonID");
                        m.MapRightKey("RoleID");
                    });


        }
    }
}
