// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryTypeMap.cs" company="">
//   
// </copyright>
// <summary>
//   The inventory type map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    /// <summary>
    /// The inventory type map.
    /// </summary>
    public class InventoryTypeMap : EntityTypeConfiguration<InventoryType>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryTypeMap"/> class.
        /// </summary>
        public InventoryTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            Property(t => t.Type).IsRequired();

            // Table & Column Mappings
            this.ToTable("InventoryTypes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Type).HasColumnName("Type");
        }

        #endregion
    }
}