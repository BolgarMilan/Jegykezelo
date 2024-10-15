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

        [HttpPut("{azon}")]
        public ActionResult<User> Put(Guid azon, UpdateUserDto updateUserDto)
        {
            using (var context = new UserDbContext())
            {

                var existingUser = context.Tantargy.FirstOrDefault(x => x.Azon == azon);

                if (existingUser != null)
                {
                    existingUser.Jegy = updateUserDto.jegy;
                    existingUser.Leiras = updateUserDto.leiras;
                    existingUser.ido = updateUserDto.ido;

                    context.Tantargy.Update(existingUser);
                    context.SaveChanges();
                }

                return StatusCode(200, existingUser);

            }
        }

        [HttpDelete]
        public ActionResult<object> Delete(Guid azon)
        {
            using (var context = new UserDbContext())
            {
                var existingUser = context.Tantargy.FirstOrDefault(x => x.Azon == azon);

                if (existingUser == null)
                {
                    return NotFound(new { message = "Felhasználó nem található!" });
                }

                context.Tantargy.Remove(existingUser);
                context.SaveChanges();

                return StatusCode(200, new { message = "Sikeres törlés!" });
            }
        }
    }
}
