using Microsoft.AspNetCore.Mvc;
using PSIU_WEB.Data.EF;
using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;

namespace PSIU_WEB.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                categoryRepository.GetCategories()
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Category? c =
                categoryRepository.GetCategoryById(id.Value);

            if (c == null)
                return NotFound();

            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            categoryRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.Create(c);
                    return View("Index", categoryRepository.GetCategories());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }

    }
}
