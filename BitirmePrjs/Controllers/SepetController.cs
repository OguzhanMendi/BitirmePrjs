using BitirmePrjs.DTOs;
using BitirmePrjs.Helper;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SepetController : ControllerBase
    {
        private readonly ISepetRepository _repo;

        public SepetController(ISepetRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("SepeteEkle")]
        public async Task<IActionResult> SepeteEkle(SepetDTO dto)
        {
            try
            {



                _repo.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        [HttpPost("SepetList")]
        public async Task<IActionResult> SepetList()
        {
            try
            {

             var list =   _repo.SepetList();

                
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("SepetAdetDegistir")]
        public async Task<IActionResult> SepetAdetDegistir(SepetAdetDTO dto)
        {
            try
            {

                _repo.sepetAdetDegistir(dto);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        [HttpPost("SepetOnayla")]
        public async Task<IActionResult> SepetOnayla(SepetOnaylaDTO dto)
        {
            try
            {
                RandomKeyHelper randomKeyHelper = new RandomKeyHelper();

                dto.siparisId = randomKeyHelper.randomKeyOlustur();

                _repo.sepetOnayla(dto);


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
