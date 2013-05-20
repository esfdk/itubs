namespace BookITService
{
    using System;
    using System.Data.Entity;

    using BookITService.Entities;
    using BookITService.Mapping;

    public class BookITContext : DbContext
    {
        #region Fields

        /// <summary>
        /// The database context object.
        /// </summary>
        [ThreadStatic]
        private static BookITContext db;

        #endregion

        #region Constructors

        static BookITContext()
        {
            Database.SetInitializer<BookITContext>(null);
        }

        public BookITContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Context getter and reloader

        /// <summary>
        /// The database context object. 
        /// </summary>
        public static BookITContext Db
        {
            get
            {
                // If db is null, instantiate it.
                return db ?? (db = new BookITContext());
            }
        }

        #endregion

        #region Entity collections
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CateringChoice> CateringChoices { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<EquipmentChoice> EquipmentChoices { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        #endregion

        #region Context Reloader
        public static void ReloadDb()
        {
            if (db != null)
            {
                db.Dispose();
            }

            db = null;
        }
        #endregion

        #region Configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookingMap());
            modelBuilder.Configurations.Add(new CateringChoiceMap());
            modelBuilder.Configurations.Add(new CateringMap());
            modelBuilder.Configurations.Add(new EquipmentChoiceMap());
            modelBuilder.Configurations.Add(new EquipmentMap());
            modelBuilder.Configurations.Add(new EquipmentTypeMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new InventoryTypeMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new RoomMap());
        }
        #endregion
    }
}
