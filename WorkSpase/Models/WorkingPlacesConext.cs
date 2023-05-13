using Microsoft.EntityFrameworkCore;

namespace WorkSpase.Models
{
    public class WorkingPlacesConext : DbContext
    {
        public WorkingPlacesConext(DbContextOptions<WorkingPlacesConext> options)
               : base(options)
        {
        }

        public DbSet<WorkingPlaces> PlacesItems { get; set; } = null!;
    }
}
