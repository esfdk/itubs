namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using ITubsService.Entities;

    public class CateringMap : EntityTypeConfiguration<Catering>
    {
        public CateringMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Caterings");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.AvailableFrom).HasColumnName("AvailableFrom");
            this.Property(t => t.AvailableTo).HasColumnName("AvailableTo");
        }
    }
}
