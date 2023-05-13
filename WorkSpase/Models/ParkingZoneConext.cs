using Microsoft.EntityFrameworkCore;
namespace WorkSpase.Models
{
    public class ParkingZoneConext : DbContext
    {
        public ParkingZoneConext(DbContextOptions<ParkingZoneConext> options)
               : base(options)
        {
        }

        public DbSet<ParkingZone> WorkItems { get; set; } = null!;
    }
}
