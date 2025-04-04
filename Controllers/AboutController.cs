using Microsoft.AspNetCore.Mvc;
using ZenithCMS.Models;
using ZenithCMS.Services;

namespace ZenithCMS.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;

        public AboutController(AboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            var aboutPages = _aboutManager.GetAllAboutPages();
            return View(aboutPages);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutPage aboutPage)
        {
            if (ModelState.IsValid)
            {
                _aboutManager.AddAboutPage(aboutPage);
                return RedirectToAction("Index");
            }
            return View(aboutPage);
        }

        public IActionResult Edit(int id)
        {
            var aboutPage = _aboutManager.GetAboutPageById(id);
            if (aboutPage == null) return NotFound();
            return View(aboutPage);
        }

        [HttpPost]
        public IActionResult Update(AboutPage aboutPage)
        {
            if (ModelState.IsValid)
            {
                _aboutManager.UpdateAboutPage(aboutPage);
                return RedirectToAction("Index");
            }
            return View("Edit", aboutPage);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _aboutManager.DeleteAboutPage(id);
            return Json(new { success = true });
        }
    }
}