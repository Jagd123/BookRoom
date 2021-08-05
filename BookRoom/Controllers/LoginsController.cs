using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookRoom.Data;
using BookRoom.Models;

namespace BookRoom.Controllers
{
    public class LoginsController : Controller
    {
        private readonly BookRoomContext _context;

        public LoginsController(BookRoomContext context)
        {
            _context = context;
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Logins/Create

        public IActionResult LoginArea()
        {
            return View();
        }

        public IActionResult Erorr()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // when anyone fills right details it will redirect to main page
        public async Task<IActionResult> AdminLogin([Bind("Id,UserName,Password")] Login login)
        {
            if(login.UserName == "Username" && login.Password == "Password")
            {
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                return RedirectToAction(nameof(AdminLogin));
            }
        }
    }
}
