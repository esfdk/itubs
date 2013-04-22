// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryMap.cs" company="">
//   
// </copyright>
// <summary>
//   The inventory map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    /// <summary>
    /// The inventory map.
    /// </summary>
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryMap"/> class.
        /// </summary>
        public InventoryMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ProductName).IsRequired();

            Property(t => t.Status).IsRequired();

            // Table & Column Mappings
            ToTable("Inventories");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.RoomID).HasColumnName("RoomID");
            Property(t => t.InventoryTypeID).HasColumnName("InventoryTypeID");

            // Relationships
            HasRequired(t => t.InventoryType).WithMany(t => t.Inventories).HasForeignKey(d => d.InventoryTypeID);
            HasRequired(t => t.Room).WithMany(t => t.Inventories).HasForeignKey(d => d.RoomID);
        }

        #endregion
    }
}