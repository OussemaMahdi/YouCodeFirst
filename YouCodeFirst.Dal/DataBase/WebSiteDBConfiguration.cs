using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace WebSite.Dal.DataBase
{
    class WebSiteDBConfiguration : DbConfiguration
    {
        public WebSiteDBConfiguration()
        {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
