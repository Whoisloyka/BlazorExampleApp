using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorExampleApp.Server.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlazorExampleDbContext>
    {
        public BlazorExampleDbContext CreateDbContext(string[] args)
        {
            // String connectionString = "data source=192.168.181.150;initial catalog=MotorAsin;user id=sa;password=Test123;MultipleActiveResultSets=True;App=EntityFramework";
            String connectionString = "Host = localhost; Database = postgres; Username = postgres; Password = Pi.141592; SearchPath=public;";

            

            var builder = new DbContextOptionsBuilder<BlazorExampleDbContext>();

            builder.UseNpgsql(connectionString);
            
            return new BlazorExampleDbContext(builder.Options);
        }
    }
}
