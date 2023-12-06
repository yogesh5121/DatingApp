using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DateAPI;
[ApiController]
[Route("api/[Controller]")]
public class UserController: ControllerBase
{
      private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]//get the all the data from database
    public async Task<ActionResult<IEnumerable<AppUser>>>GetUser()
    {
        var res = await _context.Users.ToListAsync();
        return Ok(res);
    }
    [HttpGet("{id}")]
   
    public async Task<ActionResult<AppUser>> GetById(int id)
    {
        var res = await _context.Users.FindAsync(id);
        // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
        return res; // Possible null reference argument.
#pragma warning restore CS8604 // Possible null reference argument.

    }

}
