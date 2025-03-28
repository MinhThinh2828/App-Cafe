using Microsoft.AspNetCore.Mvc;
using App_Cafe.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Cafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly CafeDbContext _context;

        public HomeController(CafeDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách cafe cho người dùng
        public IActionResult Index(string searchString)
        {
            var menuItems = from m in _context.MenuItems
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                menuItems = menuItems.Where(m => m.Name.Contains(searchString) || m.Category.Contains(searchString));
            }

            return View(menuItems.ToList());
        }
    }
}