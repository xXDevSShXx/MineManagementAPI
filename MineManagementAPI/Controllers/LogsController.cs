using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MineManagementAPI.Models;

namespace MineManagementAPI.Controllers
{
    [Route("/{controller}/{action}")]
    public class LogsController : Controller
    {
        MineManagementAPIDbContext db;
        public LogsController(MineManagementAPIDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                var logs = await db.Logs.ToListAsync();
                return Ok(logs);
        }

        [HttpPost]
        public async Task<IActionResult> Log(Log log)
        {
            if (log == null)
                return BadRequest("No \"log\" Was Provided.");
            await db.Logs.AddAsync(log);
            await db.SaveChangesAsync();

            return Ok(log);
        }
    }
}
