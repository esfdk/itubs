// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleMap.cs" company="">
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
    /// The role map.
    /// </summary>
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMap"/> class.
        /// </summary>
        public RoleMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.RoleName)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Roles");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
