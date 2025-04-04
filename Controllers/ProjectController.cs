// Controllers/ProjectController.cs
using Microsoft.AspNetCore.Mvc;
using ZenithCMS.Models;
using ZenithCMS.Services;

namespace ZenithCMS.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectManager _projectManager;

        public ProjectController(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        public IActionResult Index()
        {
            var projects = _projectManager.GetAllProjects();
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create([FromForm] ProjectDetail project, [FromForm] IFormFile ImageFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _projectManager.AddProject(project, ImageFile);
        //        return RedirectToAction("Index");
        //    }
        //    return View(project);
        //}
        [HttpPost]
        public IActionResult Create(ProjectDetail project, List<IFormFile> ImageFiles)
        {
            if (ModelState.IsValid)
            {
                _projectManager.AddProject(project, ImageFiles);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Edit(int id)
        {
            var project = _projectManager.GetProjectById(id);
            if (project == null) return NotFound();
            return View(project);
        }


        [HttpPost]
        public IActionResult Update(ProjectDetail project, List<IFormFile> NewImages, List<int> KeepImageIds)
        {
            KeepImageIds ??= new List<int>();

            if (ModelState.IsValid)
            {
                _projectManager.UpdateProject(project, NewImages, KeepImageIds);
                return RedirectToAction("Index");
            }
            return View("Edit", project);
        }

        //[HttpPost]
        //public IActionResult Update(ProjectDetail project, IFormFile ImageFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _projectManager.UpdateProject(project, ImageFile);
        //        return RedirectToAction("Index");
        //    }
        //    return View("Edit", project);
        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _projectManager.DeleteProject(id);
            return Json(new { success = true });
        }
    }
}