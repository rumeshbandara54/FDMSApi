using FDMSWebApi.Domain;
using FDMSWebApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("Login", Name = "Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=> x.UserName== userName && x.Password == password);
            if (user != null) 
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpPost("RegisterUser",Name = "RegisterUser")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var result = await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(result.Entity);
        }

    }
}
