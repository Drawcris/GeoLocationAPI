using GeoLocationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoLocationAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Location> Locations { get; set; }
    }
}
