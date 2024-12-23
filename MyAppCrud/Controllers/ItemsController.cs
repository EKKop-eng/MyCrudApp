
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context) => _context = context;

        public IActionResult Index() => View(_context.Items.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Items.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
