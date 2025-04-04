using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenithCMS.Data;
using ZenithCMS.Models;

namespace ZenithCMS.Services
{
    public class ServiceManager
    {
        private readonly ApplicationDbContext _context;

        public ServiceManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServicePage> GetAllServices()
        {
            return _context.ServicePages.ToList();
        }

        public ServicePage GetServiceById(int id)
        {
            return _context.ServicePages.Find(id);
        }

        public void AddService(ServicePage service)
        {
            service.CreatedDate = DateTime.UtcNow;
            _context.ServicePages.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(ServicePage service)
        {
            var existingService = _context.ServicePages.Find(service.Id);
            if (existingService != null)
            {
                existingService.ServiceName = service.ServiceName;
                existingService.ServiceDescription = service.ServiceDescription;
                _context.SaveChanges();
            }
        }

        public void DeleteService(int id)
        {
            var service = _context.ServicePages.Find(id);
            if (service != null)
            {
                _context.ServicePages.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}
