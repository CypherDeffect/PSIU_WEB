using Microsoft.AspNetCore.Mvc;
using PSIU_WEB.Data.EF;
using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;

namespace PSIU_WEB.Controllers
{
    public class ContentMidiaController : Controller
    {
        private IContentMidiaRepository contentMidiaRepository;

        public ContentMidiaController(IContentMidiaRepository contmidi)
        {
            contentMidiaRepository = contmidi;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                contentMidiaRepository.GetContentMidias()

                );
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            ContentMidia? cm =
                contentMidiaRepository.GetContentMidiaById(id.Value);

            if (cm == null)
                return NotFound();

            return View(cm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            contentMidiaRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(ContentMidia cm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contentMidiaRepository.Create(cm);
                    return View("Index", contentMidiaRepository.GetContentMidias());
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
