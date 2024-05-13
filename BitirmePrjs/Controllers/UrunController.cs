using BitirmePrjs.DTOs;
using BitirmePrjs.Helper;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrunController : ControllerBase
    {
        private readonly IMarkaRepository _repo;

        public UrunController(IMarkaRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("MarkaCreate")]
        public async Task<IActionResult> MarkaCreate(MarkaDTO dto)
        {
            try
            {
                if (dto == null) { return BadRequest("Veri Boş Olamaz"); }
                if (ModelState.IsValid)
                {

                    ImageHelper imageHelper = new ImageHelper();
                    var imageUrl = imageHelper.imgKaydet(dto.image);
                    dto.imgUrl = imageUrl;
                    _repo.create(dto);
                    return Ok("Başarıyla Oluştu...");

                }
                return BadRequest("Yanlış Girildi...");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("markalar")]
        public async Task<IActionResult> markalar()
        {
            try
            {
                var list = _repo.MarkalariListele();

                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private readonly string _imageRootPath = "Images"; // Resimlerin bulunduğu dizin

        [HttpGet("{resimAdi}")]
        public IActionResult GetResim(string resimAdi)
        {
            var imagePath = Path.Combine(_imageRootPath, resimAdi);

            if (System.IO.File.Exists(imagePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(fileBytes, "image/jpeg"); // MIME türünü uygun bir şekilde değiştirin
            }
            else
            {
                return NotFound();
            }
        }
    }
}
