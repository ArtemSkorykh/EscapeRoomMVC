using EscapeRoomMVC.Data;
using EscapeRoomMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomMVC.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly EscapeRoomDB _context;

        public UserController(EscapeRoomDB context)
        {
            _context = context;
        }

        // GET: user/EscapeRoom
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5, int? minPlayers = null, int? maxPlayers = null, int? fearLevel = null, int? difficultyLevel = null)
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

            var totalCount = await query.CountAsync();
            var escapeRooms = await query.Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

            ViewBag.TotalCount = totalCount;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;

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
