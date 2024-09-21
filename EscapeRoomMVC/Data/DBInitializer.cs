using EscapeRoomMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomMVC.Data
{
    public class DBInitializer
    {
        public static async Task InitializeAsync(EscapeRoomDB context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.EscapeRooms.Any())
            {
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

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            string adminEmail = "admin@example.com";
            string adminPassword = "Admin123!";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    Year = 1990
                };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            string userEmail = "user@example.com";
            string userPassword = "User123!";
            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                User user = new User
                {
                    Email = userEmail,
                    UserName = userEmail,
                    Year = 2000
                };

                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
