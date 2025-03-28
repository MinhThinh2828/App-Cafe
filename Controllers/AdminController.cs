using Microsoft.AspNetCore.Mvc;
using App_Cafe.Data;
using App_Cafe.Models;
using Microsoft.EntityFrameworkCore;

namespace App_Cafe.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly CafeDbContext _context;

        public AdminController(CafeDbContext context)
        {
            _context = context;
        }

        // Danh sách món
        [Route("index")]
        public IActionResult Index()
        {
            return View(_context.MenuItems.ToList());
        }

        // Thêm món
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _context.MenuItems.Add(menuItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }

        // Sửa món
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.MenuItems.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, MenuItem menuItem)
        {
            if (id != menuItem.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(menuItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }

        // Xóa món
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.MenuItems.Find(id);
            if (item == null) return NotFound();
            _context.MenuItems.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Chi tiết món
        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var item = _context.MenuItems.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}