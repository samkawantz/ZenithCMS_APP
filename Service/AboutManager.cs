using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenithCMS.Data;
using ZenithCMS.Models;

namespace ZenithCMS.Services
{
    public class AboutManager
    {
        private readonly ApplicationDbContext _context;

        public AboutManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AboutPage> GetAllAboutPages()
        {
            return _context.AboutPages.ToList();
        }

        public AboutPage GetAboutPageById(int id)
        {
            return _context.AboutPages.Find(id);
        }

        public void AddAboutPage(AboutPage aboutPage)
        {
            aboutPage.CreatedDate = DateTime.UtcNow;
            _context.AboutPages.Add(aboutPage);
            _context.SaveChanges();
        }

        public void UpdateAboutPage(AboutPage aboutPage)
        {
            var existing = _context.AboutPages.Find(aboutPage.Id);
            if (existing != null)
            {
                existing.Title = aboutPage.Title;
                existing.WhoWeAre = aboutPage.WhoWeAre;
                existing.AboutZMC = aboutPage.AboutZMC;
                existing.Vision = aboutPage.Vision;
                existing.Mission = aboutPage.Mission;
                existing.CoreValues = aboutPage.CoreValues;
                _context.SaveChanges();
            }
        }

        public void DeleteAboutPage(int id)
        {
            var aboutPage = _context.AboutPages.Find(id);
            if (aboutPage != null)
            {
                _context.AboutPages.Remove(aboutPage);
                _context.SaveChanges();
            }
        }
    }
}