using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Neudesic.YoEvents.AppAdmin.Core.Entities;

namespace Neudesic.YoEvents.AppAdmin.Infrastructure
{
    public interface IAppAdminDbContext
    {
        DbSet<Organization> Organizations { get; set; }

        Task<int> SaveChangesAsync();
    }
}