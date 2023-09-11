using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using boxes_api.DbConnection;
using boxes_api.Data;
using Microsoft.AspNetCore.Identity;

namespace boxes_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        private SignInManager<IdentityUser> _signInManager;

        public UserController(UserContext context, SignInManager<IdentityUser> signInManager)
        {
            _userContext = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers()
        {
            return await _userContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityUser>> GetUser(string id)
        {
            var user = await _userContext.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityUser>> PostUser(IdentityUser user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, IdentityUser user)
        {
            if (id != user.Id)
                return BadRequest();

            _userContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);

            if (!result.Succeeded)
                throw new ApplicationException("Usuário não autenticado!");

            return Ok("Usuário autenticado");
        }

        private bool UserExists(string id)
        {
            return _userContext.Users.Any(e => e.Id == id);
        }
    }
}
