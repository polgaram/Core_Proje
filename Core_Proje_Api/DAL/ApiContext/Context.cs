using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ApplicationDbContext bulunduğu dll deki projedeki IEntityTypeConfiguration dan implemente olanları al
            builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);



            base.OnModelCreating(builder);
        }
    }
}
