
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace HMS.Helpers
{
    public class ImageHelper
    {
        public static string SaveImage(IFormFile imageFile, string dir)
        {
            string finalDirPath = $"wwwroot/{dir}";
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new Exception("No file provided.");
            }

            if (!Directory.Exists(finalDirPath))
            {
                Directory.CreateDirectory(finalDirPath);
            }

            // Extract extension from file (remove leading dot to avoid ..jpg)
            string fileExtension = Path.GetExtension(imageFile.FileName).TrimStart('.');

            // Generate unique file name
            string uniqueNameForFile = $"{Guid.NewGuid()}.{fileExtension}";

            // Path to store in DB (relative to wwwroot)
            string fullPathToStoreInDB = $"{dir}/{uniqueNameForFile}";

            // Actual path on disk
            string fullPathToWrite = Path.Combine(finalDirPath, uniqueNameForFile);

            // Save image
            using (var stream = new FileStream(fullPathToWrite, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return fullPathToStoreInDB;
        }
    }
}
