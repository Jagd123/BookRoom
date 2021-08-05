using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookRoom.Data;
using BookRoom.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookRoom.Controllers
{
        public class RoomBookController : Controller
        {
            private readonly BookRoomContext _context;

            public RoomBookController(BookRoomContext context)
            {
                _context = context;
            }

        // GET: RoomBook
        public async Task<IActionResult> Index()
            {
               return View(await _context.RoomBook.ToListAsync());               
            }

        // GET: RoomBook/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var RoomBook = await _context.RoomBook
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (RoomBook == null)
                {
                    return NotFound();
                }

                return View(RoomBook);
            }
        public IActionResult RoomNotFound()
        {
            return View();
        }
         public IActionResult RoomBooked()
        {
            return View();
        }
        
        // GET: RoomBook/Create
        public IActionResult Create()
            {
            var Rooms = _context.Room.ToList();
            if (Rooms.Count > 0)
            {
                Rooms.Insert(0, new Room { Id = 0, RoomType = "Select Room" });
                ViewBag.ListRooms = Rooms;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(RoomNotFound));
            }
            }



        // POST: RoomBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,NumberOfRooms,RoomBookingDate,RoomId")] RoomBook RoomBook)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(RoomBook);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(RoomBooked));
                }
                return View(RoomBook);
            }

        // GET: RoomBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var RoomBook = await _context.RoomBook.FindAsync(id);
                if (RoomBook == null)
                {
                    return NotFound();
                }
                return View(RoomBook);
            }

        // POST: RoomBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,NumberOfRooms,RoomBookingDate,RoomId")] RoomBook RoomBook)
            {
                if (id != RoomBook.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(RoomBook);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RoomBookExists(RoomBook.Id))
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
                return View(RoomBook);
            }

        // GET: RoomBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var RoomBook = await _context.RoomBook
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (RoomBook == null)
                {
                    return NotFound();
                }

                return View(RoomBook);
            }

        // POST: RoomBook/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var RoomBook = await _context.RoomBook.FindAsync(id);
                _context.RoomBook.Remove(RoomBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool RoomBookExists(int id)
            {
                return _context.RoomBook.Any(e => e.Id == id);
            }
        }
    }
