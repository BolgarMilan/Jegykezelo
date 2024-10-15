using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jegyek.Models;
using static Jegyek.Models.Dto;

namespace Jegyek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(201, context.Tantargy.ToList());
            }
        }

        [HttpPost]
        public ActionResult<User> Post(CreateUserDto CreateUserDto)
        {
            var user = new User
            {
                Azon = Guid.NewGuid(),
                Jegy = CreateUserDto.jegy,
                Leiras = CreateUserDto.leiras,
                ido = CreateUserDto.ido
            };

            using (var context = new UserDbContext())
            {
                context.Tantargy.Add(user);
                context.SaveChanges();
                return StatusCode(201, user);
            }
        }
    }
}
