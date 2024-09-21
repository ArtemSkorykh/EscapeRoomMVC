using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EscapeRoomMVC.Models;

namespace EscapeRoomMVC.Data
{
    public class EscapeRoomDB : IdentityDbContext<User>
    {
        public EscapeRoomDB(DbContextOptions<EscapeRoomDB> options) : base(options) { }

        public DbSet<EscapeRoom> EscapeRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}