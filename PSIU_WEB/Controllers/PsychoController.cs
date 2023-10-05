using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIU_WEB.Data.Interface;
using PSIU_WEB.Models;

namespace PSIU_WEB.Controllers
{
    public class PsychoController : Controller
    {
        private readonly IPsychoRepository psychoRepository;

        public PsychoController(IPsychoRepository _psychoRepo)
        {
            psychoRepository = _psychoRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var psychos = psychoRepository.GetPsychos();
            return View(psychos);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psycho = psychoRepository.GetPsychoById(id.Value);

            if (psycho == null)
            {
                return NotFound();
            }

            return View(psycho);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Psycho psycho)
        {
            if (ModelState.IsValid)
            {
                psychoRepository.Create(psycho);
                return RedirectToAction(nameof(Index));
            }

            return View(psycho);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psycho = psychoRepository.GetPsychoById(id.Value);

            if (psycho == null)
            {
                return NotFound();
            }

            return View(psycho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Psycho psycho)
        {
            if (id != psycho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    psychoRepository.Update(psycho);
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(psycho);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psycho = psychoRepository.GetPsychoById(id.Value);

            if (psycho == null)
            {
                return NotFound();
            }

            return View(psycho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var psycho = psychoRepository.GetPsychoById(id);

            if (psycho == null)
            {
                return NotFound();
            }

            psychoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
