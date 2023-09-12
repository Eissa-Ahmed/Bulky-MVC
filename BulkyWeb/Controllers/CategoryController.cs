using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        #region Ctor
        private readonly ApplicationDbContext dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var items = await dbContext.Categories.ToListAsync();
            return View(items);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Create(Category model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name Equal Display Order!");
            }
            if (ModelState.IsValid)
            {
                await dbContext.Categories.AddAsync(model);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();


            var item = await dbContext.Categories.FindAsync(id);
            if (item == null)
                return NotFound();

            dbContext.Categories.Remove(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
