using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Data
{
    public class ServiceAutoContext : DbContext
    {
        public ServiceAutoContext(DbContextOptions<ServiceAutoContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
