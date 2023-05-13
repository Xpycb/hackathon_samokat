using Microsoft.EntityFrameworkCore;

namespace WorkSpase.Models
{
    public class MeetingZoneConext : DbContext
    {
        public MeetingZoneConext(DbContextOptions<MeetingZoneConext> options)
              : base(options)
        {
        }

        public DbSet<MeetingZone> MeetItems { get; set; } = null!;
    }
}
