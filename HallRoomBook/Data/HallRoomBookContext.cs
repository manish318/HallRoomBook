using HallRoomBook.Models;
using Microsoft.EntityFrameworkCore;

namespace HallRoomBook.Data
{
    public class HallRoomBookContext : DbContext
    {
        public HallRoomBookContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<MeetingHall> MeetingHall { get; set; }
    }
}
