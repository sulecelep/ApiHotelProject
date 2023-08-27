using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult TokenOlustur()
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestToken()
        {
            return Ok("Hoş Geldiniz");
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }
        [Authorize(Roles ="Admin, Visitor")]
        [HttpGet("[action]")]
        public IActionResult TestRole()
        {
            return Ok("Admin/Visitor Başarılı Şekilde Giriş Yaptı");
        }
    }
}
