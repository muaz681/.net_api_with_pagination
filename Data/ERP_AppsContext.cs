using FinalApi.Models.SPModels;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Data
{
    public partial class ERP_AppsContext: DbContext
    {
        
        public ERP_AppsContext()
        {

        }
        public ERP_AppsContext(DbContextOptions<ERP_AppsContext> options)
        : base(options)
        {
        }
        public virtual DbSet<sprModels> SprModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=10.24.50.119;Initial Catalog=ERP_APPS;Persist Security Info=True;User ID=rNwUs@Ag;Password=a2sLs@Ag;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");


        //protected readonly IConfiguration Configuration;

        //public ERP_AppsContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Apps_Connection"));
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<sprModels>().HasNoKey();
        //}
        //public DbSet<sprModels> SprModels { get; set; }



    }
}
