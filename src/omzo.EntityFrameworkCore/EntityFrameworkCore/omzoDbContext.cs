using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using omzo.Authorization.Roles;
using omzo.Authorization.Users;
using omzo.MultiTenancy;
using omzo.Categories;

namespace omzo.EntityFrameworkCore
{
    public class omzoDbContext : AbpZeroDbContext<Tenant, Role, User, omzoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Category> Categories  { get; set; }


        public omzoDbContext(DbContextOptions<omzoDbContext> options)
            : base(options)
        {
        }
    }
}
