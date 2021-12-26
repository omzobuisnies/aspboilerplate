using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace omzo.EntityFrameworkCore
{
    public static class omzoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<omzoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<omzoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
