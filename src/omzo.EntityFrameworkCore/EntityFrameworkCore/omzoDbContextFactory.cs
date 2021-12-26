using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using omzo.Configuration;
using omzo.Web;

namespace omzo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class omzoDbContextFactory : IDesignTimeDbContextFactory<omzoDbContext>
    {
        public omzoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<omzoDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            omzoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(omzoConsts.ConnectionStringName));

            return new omzoDbContext(builder.Options);
        }
    }
}
