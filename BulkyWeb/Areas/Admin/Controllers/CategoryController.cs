using Bulky.BL.Models;
using Bulky.DAL.Repository;
using Bulky.DAL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Ctor
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public IActionResult Index()
        {
            var items = unitOfWork.CategoryRepo.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult Create(Category model)
        {
            if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name Equal Display Order!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepo.Add(model);
                unitOfWork.Save();
                TempData["Success"] = "Category Is Created !";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || id == null)
                return NotFound();


            var item = unitOfWork.CategoryRepo.Get(i => i.Id == id);
            if (item == null)
                return NotFound();

            unitOfWork.CategoryRepo.Remove(item);
            unitOfWork.Save();
            TempData["Success"] = "Category Is Deleted !";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var item = unitOfWork.CategoryRepo.Get(i => i.Id == id);
            if (item != null)
                return View(item);

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    unitOfWork.CategoryRepo.Update(model);
                    unitOfWork.Save();
                    TempData["Success"] = "Category Is Updated !";
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
