using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookRoom.Data;
using BookRoom.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace BookRoom.Controllers
{
        public class RoomController : Controller
        {
            private readonly BookRoomContext _context;

            public RoomController(BookRoomContext context)
            {
                _context = context;
            }

            // GET: Room
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Room.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Room.ToListAsync());
            }
        
            // GET: Room/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Room = await _context.Room
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Room == null)
                {
                    return NotFound();
                }

                return View(Room);
            }

            // GET: Room/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Room/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,RoomType,RoomNo,Price")] Room Room)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Room);
            }

            // GET: Room/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Room = await _context.Room.FindAsync(id);
                if (Room == null)
                {
                    return NotFound();
                }
                return View(Room);
            }

            // POST: Room/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,RoomType,RoomNo,Price")] Room Room)
            {
                if (id != Room.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Room);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RoomExists(Room.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(Room);
            }

            // GET: Room/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Room = await _context.Room
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Room == null)
                {
                    return NotFound();
                }

                return View(Room);
            }

            // POST: Room/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Room = await _context.Room.FindAsync(id);
                _context.Room.Remove(Room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool RoomExists(int id)
            {
                return _context.Room.Any(e => e.Id == id);
            }
        }
    }