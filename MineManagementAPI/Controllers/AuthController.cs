using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MineManagementAPI.Models;

namespace MineManagementAPI.Controllers
{
    [Route("/{controller}/{action}")]
    public class AuthController : Controller
    {
        MineManagementAPIDbContext db;
        public AuthController(MineManagementAPIDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetMe(int userId)
        {
            if (userId == 0)
                return BadRequest("No \"userId\" Was Provided");
            var user = await db.Users.FindAsync(userId);
            if (user == null)
                return NotFound($"No User With userId: {userId} Was Found");
            return Ok(new UserVM { FirstName = user.FirstName,LastName = user.LastName});
        }

        [HttpPost]
        public ActionResult Login(int persoalID)
        {
            if(persoalID == 0) 
                return BadRequest("No \"personalId\" Was Provided");
            var user = db.Users.Where(entity=> entity.PersnalID == persoalID).FirstOrDefault();
            if (user == null)
                return NotFound($"No User With personalId: {persoalID} Was Found");
            return Ok(user.UserId);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
                return BadRequest("No \"user\" Was Provided");
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
