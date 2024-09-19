using EscapeRoomMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomMVC.Data
{
    public class DBInitializer
    {
        public static void Initialize(EscapeRoomDB context)
        {
            if (context.EscapeRooms.Any()) return;

            var escapeRooms = new[]
            {
            new EscapeRoom
            {
                Name = "Побег из тюрьмы",
                Description = "Вы в заточении, у вас час чтобы сбежать!",
                Duration = 1,
                MinPlayers = 2,
                MaxPlayers = 6,
                MinAge = 12,
                Address = "ул. Свободы, 1",
                PhoneNumber = "123-456-7890",
                Email = "prison_escape@example.com",
                Company = "КвестоМания",
                Rating = 4.8,
                FearLevel = 3,
                DifficultyLevel = 4,
                Logo = "/images/prison_escape_logo.png"
            },
            new EscapeRoom
            {
                Name = "Зомби-апокалипсис",
                Description = "Смогут ли вы выжить среди зомби?",
                Duration = 1.4,
                MinPlayers = 3,
                MaxPlayers = 8,
                MinAge = 16,
                Address = "ул. Выживших, 10",
                PhoneNumber = "987-654-3210",
                Email = "zombie_apocalypse@example.com",
                Company = "ХоррорКвест",
                Rating = 4.5,
                FearLevel = 5,
                DifficultyLevel = 5,
                Logo = "/images/zombie_apocalypse_logo.png"
            }
        };

            context.EscapeRooms.AddRange(escapeRooms);
            context.SaveChanges();
        }
    }
}
