using BitirmePrjs.DTOs;
using BitirmePrjs.Helper;
using BitirmePrjs.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
                    if (kullanici != null)
                    {
                        GenerateToken generateToken = new GenerateToken();
                        var token = generateToken.GenerateJwtToken(kullanici.email, kullanici.rol);
                        var response = new
                        {
                            email = kullanici.email,
                            sifre = kullanici.sifre,
                            rol = kullanici.rol,
                            token = token
                        };
                        return Ok(response);
                    }


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
                    var kullanici = _repo.create(dto);
                    if (kullanici != null)
                    {
                        GenerateToken generateToken = new GenerateToken();
                        var token = generateToken.GenerateJwtToken(kullanici.email, kullanici.rol);
                        var response = new
                        {
                            email = kullanici.email,
                            sifre = kullanici.sifre,
                            rol = kullanici.rol,
                            token = token
                        };
                        return Ok(response);
                    }

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
