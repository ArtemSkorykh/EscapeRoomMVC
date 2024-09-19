namespace EscapeRoomMVC.Models
{
    public class EscapeRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public double Duration { get; set; } 
        public int MinPlayers { get; set; } 
        public int MaxPlayers { get; set; } 
        public int MinAge { get; set; } 
        public string Address { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public string Company { get; set; } 
        public double Rating { get; set; }
        public int FearLevel { get; set; } 
        public int DifficultyLevel { get; set; } 
        public string Logo { get; set; } 
    }
}
