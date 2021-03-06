using Microsoft.EntityFrameworkCore;

namespace REST_API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Batteries> Batteries { get; set; } // specifies all informations about DB multiple tables

        public DbSet<Elevators> Elevators { get; set; } 

        public DbSet<Columns> Columns {get; set;}

        public DbSet<Buildings> Buildings {get; set;}

        public DbSet<Leads> Leads {get; set;}
        
        public DbSet<Customers> Customers {get; set;}

        public DbSet<Employees> Employees {get; set;}
        public DbSet<Interventions> Interventions {get; set;}
        public DbSet<Quotes> Quotes {get; set;}
        public DbSet<Addresses> Addresses {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batteries>()
                .ToTable("batteries");

            modelBuilder.Entity<Elevators>()
                .ToTable("elevators");

            modelBuilder.Entity<Columns>()
                .ToTable("columns");

            modelBuilder.Entity<Buildings>()
                .ToTable("buildings");

            modelBuilder.Entity<Leads>()
                .ToTable("leads");

            modelBuilder.Entity<Customers>()
                .ToTable("customers");

            modelBuilder.Entity<Employees>()
                .ToTable("employees");

            modelBuilder.Entity<Interventions>()
                .ToTable("interventions");

            modelBuilder.Entity<Quotes>()
                .ToTable("quotes"); 
                
            modelBuilder.Entity<Addresses>()
                .ToTable("addresses");                
                               



        }

    }
}



// public class YourContext : DbContext
// {
//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//         builder.Entity<MyModel>(entity => {
//             entity.ToTable("MyModelTable");
//         });
//     }
// }
