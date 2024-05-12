using BitirmePrjs.DTOs;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo;

        public LoginController(ILoginRepository repo)
        {
            _repo = repo;
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                if (dto == null) { return BadRequest("Veriler Boş Olamaz...!"); }
                if (ModelState.IsValid)
                {
                    var kullanici = _repo.login(dto);
                    return Ok(kullanici);

                }
                return BadRequest("Email veya Şifre Yanlış...");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



       
        [HttpPost("Create")]
        public async Task<IActionResult> Create(LoginDTO dto)
        {

            try
            {
                if (dto == null) { return BadRequest("Veriler Boş Olamaz...!"); }

                if (ModelState.IsValid)
                {
                    _repo.create(dto);
                    return Ok("Başarıyla Oluştu");
                }
                return BadRequest("email veya Şifre Yanlış....");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


    }
}
