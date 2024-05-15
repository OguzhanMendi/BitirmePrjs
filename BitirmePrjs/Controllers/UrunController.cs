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
        private readonly IUrunRepository _urunRepo;

        public UrunController(IMarkaRepository repo, IUrunRepository urunRepo)
        {
            _repo = repo;
            _urunRepo = urunRepo;
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



        [HttpPost("urunCreate")]
        public async Task<IActionResult> urunCreate(UrunDTO dto)
        {
            try
            {
                if (dto == null) { return BadRequest("Veri Boş Olamaz"); }
                if (ModelState.IsValid)
                {

                    ImageHelper imageHelper = new ImageHelper();
                    var imageUrl = imageHelper.imgKaydet(dto.image);
                    dto.imgUrl = imageUrl;
                    dto.aktif = true;
                    _urunRepo.create(dto);
                    return Ok("Başarıyla Oluştu...");

                }
                return BadRequest("Yanlış Girildi...");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("urunler")]
        public async Task<IActionResult> urunler()
        {
            try
            {
                var list = _urunRepo.urunList();

                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("urunBul")]
        public async Task<IActionResult> urunBul(int id)
        {
            try
            {
                var urun = _urunRepo.urunbul(id);

                return Ok(urun);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("urunUpdate")]
        public async Task<IActionResult> urunUpdate(UrunDTO dto)
        {
            try
            {
                ImageHelper imageHelper = new ImageHelper();
                var imageUrl = imageHelper.imgKaydet(dto.image);
                dto.imgUrl = imageUrl;
                _urunRepo.update(dto);

                return Ok("Başarılır");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("urunSil")]
        public async Task<IActionResult> urunSil(int id)
        {
            try
            {
                _urunRepo.sil(id);

                return Ok("Başarılır");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
