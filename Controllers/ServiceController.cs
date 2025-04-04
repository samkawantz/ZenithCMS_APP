using Microsoft.AspNetCore.Mvc;
using ZenithCMS.Models;
using ZenithCMS.Services;
using System.Collections.Generic;

namespace ZenithCMS.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceManager _serviceManager;

        public ServiceController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            List<ServicePage> services = _serviceManager.GetAllServices();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServicePage service)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.AddService(service);
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Edit(int id)
        {
            var service = _serviceManager.GetServiceById(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        public IActionResult Update(ServicePage service)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.UpdateService(service);
                return RedirectToAction("Index");
            }
            return View("Edit", service);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _serviceManager.DeleteService(id);
            return Json(new { success = true });
        }
    }
}
