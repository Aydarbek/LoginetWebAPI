using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DBContext _context;

        public UsersController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            IEnumerable<User> Users = await _context.Users.ToListAsync();

            if (Users == null | Users.Count() == 0)
                return NotFound();

            return Ok(Users); 
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            User User = await _context.Users.FindAsync(id);
            
            if (User == null)
                return NotFound();

            return Ok(User);
        }



    }
}
