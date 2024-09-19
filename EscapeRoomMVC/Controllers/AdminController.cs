using EscapeRoomMVC.Data;
using EscapeRoomMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscapeRoomMVC.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly EscapeRoomDB _context;

        public AdminController(EscapeRoomDB context)
        {
            _context = context;
        }

        // GET: admin/EscapeRoom
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var escapeRooms = await _context.EscapeRooms.ToListAsync();
            return View(escapeRooms);
        }

        // GET: admin/EscapeRoom/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/EscapeRoom/create
        [HttpPost("create")]
        public async Task<IActionResult> Create(EscapeRoom escapeRoom)
        {
            if (ModelState.IsValid)
            {
                _context.EscapeRooms.Add(escapeRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escapeRoom);
        }

        // GET: admin/EscapeRoom/edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var escapeRoom = await _context.EscapeRooms.FindAsync(id);
            if (escapeRoom == null)
            {
                return NotFound();
            }
            return View(escapeRoom);
        }

        // POST: admin/EscapeRoom/edit/5
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, EscapeRoom escapeRoom)
        {
            if (id != escapeRoom.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(escapeRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escapeRoom);
        }

        // GET: admin/EscapeRoom/delete/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var escapeRoom = await _context.EscapeRooms.FindAsync(id);
            if (escapeRoom == null)
            {
                return NotFound();
            }
            return View(escapeRoom);
        }

        // POST: admin/EscapeRoom/delete/5
        [HttpPost("delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escapeRoom = await _context.EscapeRooms.FindAsync(id);
            _context.EscapeRooms.Remove(escapeRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
