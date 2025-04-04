// Services/ProjectManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenithCMS.Data;
using ZenithCMS.Models;

namespace ZenithCMS.Services
{
    public class ProjectManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjectManager(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public List<ProjectDetail> GetAllProjects()
        {
            return _context.ProjectDetails.ToList();
        }

        public ProjectDetail GetProjectById(int id)
        {
            return _context.ProjectDetails
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddProject(ProjectDetail project, List<IFormFile> imageFiles)
        {
            try
            {
                if (imageFiles != null)
                {
                    foreach (var file in imageFiles.Take(5))
                    {
                        ValidateImageFile(file);
                        var imagePath = UploadImage(file);
                        project.Images.Add(new ProjectImage { ImagePath = imagePath });
                    }
                }

                _context.ProjectDetails.Add(project);
                _context.SaveChanges();
            }
            catch
            {
                foreach (var img in project.Images)
                    DeleteImage(img.ImagePath);
                throw;
            }
        }


        private void ValidateImageFile(IFormFile file)
        {
            if (file.Length > 20971520)
                throw new Exception($"File {file.FileName} exceeds 20MB limit");

            if (!file.ContentType.StartsWith("image/"))
                throw new Exception($"{file.FileName} is not an image file");
        }


        public void UpdateProject(ProjectDetail project, List<IFormFile> newImages, List<int> keepImageIds)
        {
            var existing = _context.ProjectDetails
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == project.Id);

            if (existing == null) return;

            // Update properties
            existing.ProjectSummary = project.ProjectSummary;
            existing.ClientName = project.ClientName;
            existing.Category = project.Category;
            existing.StartDate = project.StartDate;
            existing.EndDate = project.EndDate;
            existing.Website = project.Website;

            // Remove unchecked images
            var toRemove = existing.Images
                .Where(img => !keepImageIds.Contains(img.Id))
                .ToList();

            foreach (var img in toRemove)
            {
                DeleteImage(img.ImagePath);
                existing.Images.Remove(img);
            }

            // Add new images
            if (newImages != null)
            {
                foreach (var file in newImages.Take(5 - existing.Images.Count))
                {
                    ValidateImageFile(file);
                    var imagePath = UploadImage(file);
                    existing.Images.Add(new ProjectImage { ImagePath = imagePath });
                }
            }

            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = _context.ProjectDetails
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);

            if (project != null)
            {
                // Delete all associated images
                foreach (var image in project.Images)
                {
                    DeleteImage(image.ImagePath);
                }

                _context.ProjectDetails.Remove(project);
                _context.SaveChanges();
            }
        }

     

        private string UploadImage(IFormFile file)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            // Ensure the directory exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return $"/uploads/{uniqueFileName}";
        }


        //private string UploadImage(IFormFile file)
        //{
        //    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
        //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyTo(fileStream);
        //    }
        //    return $"/uploads/{uniqueFileName}";
        //}

        private void DeleteImage(string imagePath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, imagePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}