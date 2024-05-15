using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BitirmePrjs.Helper
{
    public class ImageHelper
    {
        public string imgKaydet(IFormFile formFile)
        {
            //using var image = Image.Load(formFile.OpenReadStream()); // dosyayı oku al
            //image.Mutate(a => a.Resize(120, 120));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
            //Guid guid = Guid.NewGuid();

            //image.Save($"Images/{guid}.jpg");  // dosyayı images altına kaydet
            //var imgurl = $"{guid}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.

            //return imgurl;

            using var image = Image.Load(formFile.OpenReadStream());
            Guid guid = Guid.NewGuid();
            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileName = $"{guid}{fileExtension}";
            image.Save($"Images/{fileName}");
            var imgUrl = fileName;
            return imgUrl;
        }

    }
}
