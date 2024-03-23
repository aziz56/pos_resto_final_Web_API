using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;


namespace pos.DAL.DAL
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["pos_restoConnectionString"] == null)
            {
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("pos_restoConnectionString");
            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["pos_restoConnectionString"].ConnectionString;
            return connString;

            //public static string GetConnectionString()
            //{
            //        IConfigurationRoot configuration = new ConfigurationBuilder()
            //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    return configuration.GetConnectionString("pos_restoConnectionString");
            //}

        }
    }
}
    

