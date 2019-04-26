namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LaptopShopDbContext : DbContext
    {
        public LaptopShopDbContext()
            : base("name=LaptopShopDbContext")
        {
        }

        public virtual DbSet<bill_detail> bill_detail { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        public virtual DbSet<type_products> type_products { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.phone_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.image)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<type_products>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
