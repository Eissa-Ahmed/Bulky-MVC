using Bulky.DAL.Repository.IRepository;
using Bulky.Model.Models;
using Microsoft.AspNetCore.Mvc;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        #region Ctor
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public IActionResult Index()
        {
            var items = unitOfWork.ProductRepo.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult Create(Prouduct model)
        {
            /*if (model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name Equal Display Order!");
            }*/
            if (ModelState.IsValid)
            {
                unitOfWork.ProductRepo.Add(model);
                unitOfWork.Save();
                TempData["Success"] = "Product Is Created !";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || id == null)
                return NotFound();


            var item = unitOfWork.ProductRepo.Get(i => i.Id == id);
            if (item == null)
                return NotFound();

            unitOfWork.ProductRepo.Remove(item);
            unitOfWork.Save();
            TempData["Success"] = "Product Is Deleted !";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var item = unitOfWork.ProductRepo.Get(i => i.Id == id);
            if (item != null)
                return View(item);

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Prouduct model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    unitOfWork.ProductRepo.Update(model);
                    unitOfWork.Save();
                    TempData["Success"] = "Product Is Updated !";
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
