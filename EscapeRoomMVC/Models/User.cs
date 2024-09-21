using Microsoft.AspNetCore.Identity;

namespace EscapeRoomMVC.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
