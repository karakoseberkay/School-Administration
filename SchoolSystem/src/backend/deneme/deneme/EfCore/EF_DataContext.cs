using System;
using Microsoft.EntityFrameworkCore;

namespace deneme.EfCore
{
   
    public class EF_DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=postgres;");

        public EF_DataContext(DbContextOptions<EF_DataContext>options): base(options) { }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }


}

