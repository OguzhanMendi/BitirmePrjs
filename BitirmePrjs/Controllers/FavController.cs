using BitirmePrjs.DTOs;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavController : ControllerBase
    {
        private readonly IFavRepository _repo;

        public FavController(IFavRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("favEkle")]
        public async Task<IActionResult> favEkle(FavDTO dto)
        {
            try
            {

                _repo.create(dto);
                return Ok();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("favSil")]
        public async Task<IActionResult> favSil(FavDTO dto)
        {
            try
            {

                _repo.sil(dto);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPost("favList")]
        public async Task<IActionResult> favList()
        {
            try
            {

                var list = _repo.List();

                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




    }
}
