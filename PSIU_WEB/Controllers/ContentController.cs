using Microsoft.AspNetCore.Mvc;
using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;
using PSIU_WEB.Data.EF;

namespace PSIU_WEB.Controllers
{
    public class ContentController : Controller
    {
        private IContentRepository contentRepository;

        public ContentController(IContentRepository repo)
        {
            contentRepository = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                contentRepository.GetContents()
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Content? c =
                contentRepository.GetContentById(id.Value);

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

            contentRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Content c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contentRepository.Create(c);
                    return View("Index", contentRepository.GetContents());
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
