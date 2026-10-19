namespace Gubai_Autoservice
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.IO.Pipes;

    public partial class Губайдуллин_АвтосервимсEntities : DbContext
    {

        private static Губайдуллин_АвтосервимсEntities _context;

        public static Губайдуллин_АвтосервимсEntities GetContext()
        {
            if (_context == null)
                _context = new Губайдуллин_АвтосервимсEntities();
            return _context;
        }

        public Губайдуллин_АвтосервимсEntities()
            : base("name=Губайдуллин_АвтосервимсEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        public virtual DbSet<DocumentByService> DocumentByService { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhoto { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
    }
}