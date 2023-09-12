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
                TempData["Success"] = "Category Is Created !";
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
            TempData["Success"] = "Category Is Deleted !";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var item = dbContext.Categories.Find(id);
            if (item != null)
                return View(item);

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category model)
        {
            if (ModelState.IsValid)
            {
                /*var item = dbContext.Categories.Find(model.Id);*/
                if (model != null)
                {
                     dbContext.Categories.Update(model);
                    await dbContext.SaveChangesAsync();
                    TempData["Success"] = "Category Is Updated !";
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
