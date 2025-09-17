using Microsoft.AspNetCore.Mvc;




namespace HMS.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }

    }
}
