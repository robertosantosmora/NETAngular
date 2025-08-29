using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetAppUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("id")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var user = await _context.Users.FindAsync(id);

            return user is null ? NotFound() : user;
        }
    }
}
