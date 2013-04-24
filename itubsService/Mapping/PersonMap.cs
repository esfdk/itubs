// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonMap.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the PersonMap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;


    /// <summary>
    /// The person map.
    /// </summary>
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonMap"/> class.
        /// </summary>
        public PersonMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name)
                .IsRequired();

            Property(t => t.Email)
                .IsRequired();

            Property(t => t.Token)
                .IsRequired();

            // Table & Column Mappings
            ToTable("People");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Token).HasColumnName("Token");

            // Relationships
            HasMany(t => t.Roles)
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
