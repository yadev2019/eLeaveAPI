using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eLeaveAPI.Models
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();
        //    //optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ServConn"]); //Server Connection
        //    //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DBApi;Trusted_Connection=True;");
        //}
        public DbSet<User> Users { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<Refer> Refers { get; set; }
        public DbSet<Usage> Usages { get; set; }
        public DbSet<Event> Events { get; set; }



        public DbQuery<vw_event> vw_events { get; set; }
        public DbQuery<vw_baland> vw_balands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<vw_event>().ToView("vw_event");
            modelBuilder.Query<vw_baland>().ToView("vw_baland");


        }
    }
}
