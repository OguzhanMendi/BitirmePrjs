using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public AdminController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("UserList")]
        public async Task<IActionResult> UserList()
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


        [HttpPost("UserSil")]
        public async Task<IActionResult> UserSil(int id)
        {
            try
            {
                _repo.Sil(id);
                return Ok("");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
