namespace ITubsService.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    using Models;

    public class CateringMap : EntityTypeConfiguration<Catering>
    {
        public CateringMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.ProductName)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Caterings");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Price).HasColumnName("Price");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.AvailableFrom).HasColumnName("AvailableFrom");
            Property(t => t.AvailableTo).HasColumnName("AvailableTo");
        }
    }
}
