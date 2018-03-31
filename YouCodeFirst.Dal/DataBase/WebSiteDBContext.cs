using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebSite.Dal.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using WebSite.Dal.Models.Account;


namespace WebSite.Dal.DataBase
{
    public class WebSiteDBContext : IdentityDbContext<ApplicationUser>
    {
        public const string TestConnectionString = "Data Source=DESKTOP-DD9T33S;Initial Catalog=WebSiteDBTest;Integrated Security=SSPI;";
        
        //public const string TestConnectionString = "Data Source=bigdb;Initial Catalog=WebSiteDBTest;Integrated Security=SSPI;";
        public const string ProdConnectionString = "Data Source=bigdb;Initial Catalog=WebSiteDB;Integrated Security=SSPI;";

        public WebSiteDBContext()
            : base(WebSiteDBContext.GetConnectionString())
        {
            //Database.SetInitializer<WebSiteDBContext>(null);//Désactiver l'initialiseur de bdd

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebSiteDBContext, WebSite.Dal.Migrations.Configuration>("WebApplicationDBConnectionString"));

            Database.SetInitializer<WebSiteDBContext>(new WebSiteDBInitializer());
        }
        //public DbSet<Client> Clients { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ScanFile> ScanFiles { get; set; }
        public DbSet<ListAttribute> ListAttributes { get; set; }
        public DbSet<WebSite.Dal.Models.Attribute> Attributes { get; set; }
        public DbSet<Key> Keys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static string GetConnectionString()
        {
#if DEBUG
            return WebSiteDBContext.TestConnectionString;
#else
            return WebSiteDBContext.ProdConnectionString;
#endif
        }

        public static WebSiteDBContext Create()
        {
            return new WebSiteDBContext();
        }
    }

}
