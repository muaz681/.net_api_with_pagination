using FinalApi.Models.SPModels;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Data
{
    public class ERP_HR_Context:DbContext
    {
        //protected readonly IConfiguration _configuration;
        //public ERP_HR_Context(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //}
        public ERP_HR_Context()
        {

        }
        public ERP_HR_Context(DbContextOptions<ERP_HR_Context> options)
        : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=aal-esql01;Initial Catalog=ERP_HR;User ID=NPrNwUs@Ag;Password=NPa2sLs@Ag;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeJob>().HasNoKey();
        //}
        public DbSet<EmployeJob> EmployeJob { get; set; }
    }
}
