using EscapeRoomMVC.Data;
using EscapeRoomMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomMVC.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly EscapeRoomDB _context;

        public UserController(EscapeRoomDB context)
        {
            _context = context;
        }

        // GET: user/EscapeRoom
        [HttpGet]
        public async Task<IActionResult> Index(int? minPlayers, int? maxPlayers, int? fearLevel, int? difficultyLevel)
        {
            var query = _context.EscapeRooms.AsQueryable();

            if (minPlayers.HasValue)
            {
                query = query.Where(e => e.MinPlayers >= minPlayers.Value);
            }
            if (maxPlayers.HasValue)
            {
                query = query.Where(e => e.MaxPlayers <= maxPlayers.Value);
            }
            if (fearLevel.HasValue)
            {
                query = query.Where(e => e.FearLevel == fearLevel.Value);
            }
            if (difficultyLevel.HasValue)
            {
                query = query.Where(e => e.DifficultyLevel == difficultyLevel.Value);
            }

            var escapeRooms = await query.ToListAsync();
            return View(escapeRooms);
        }

        // GET: user/EscapeRoom/details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var escapeRoom = await _context.EscapeRooms.FindAsync(id);
            if (escapeRoom == null)
            {
                return NotFound();
            }
            return View(escapeRoom);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            var rooms = await _context.EscapeRooms
                .Where(r => r.Name.Contains(name))
                .ToListAsync();

            return View("Index", rooms); 
        }
    }
}
