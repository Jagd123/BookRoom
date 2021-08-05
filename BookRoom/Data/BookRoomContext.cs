using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRoom.Data
{
    public class BookRoomContext : DbContext
    {
        public BookRoomContext (DbContextOptions<BookRoomContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }

        public DbSet<RoomBook> RoomBook { get; set; }

        public DbSet<Query> Query { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
