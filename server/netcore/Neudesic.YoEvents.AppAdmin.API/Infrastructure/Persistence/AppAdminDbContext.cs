using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.AppAdmin.Core.Entities;
using System.Threading.Tasks;

namespace Neudesic.YoEvents.AppAdmin.Infrastructure
{
    public class AppAdminDbContext : DbContext, IAppAdminDbContext
    {
        public AppAdminDbContext(DbContextOptions<AppAdminDbContext> options)
           : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("org");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppAdminDbContext).Assembly);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
