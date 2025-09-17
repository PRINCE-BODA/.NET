using HMS.Helpers;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HMS.Controllers
{
    public class ImageController : Controller
    {

        [HttpGet]
        public IActionResult ImageAddEdit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ImageAdd(ImageModel img)
        {
            ViewBag.ImageName = img.ImageName;

            string filePath = "";
            try
            {
                filePath = ImageHelper.SaveImage(img.Image, "Profile");
                ViewBag.ImagePath = filePath;
            }
            catch (System.Exception)
            {
                ViewBag.ImagePath = "";
                Console.WriteLine("File not provided or error occurred.");
            }

            return View("ImageAdd", img);
        }

    }
}
