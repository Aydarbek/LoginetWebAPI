using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginetWebAPI.Models;

namespace LoginetWebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly DBContext _context;

        public AlbumsController(DBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<Album> Albums = await _context.Albums.ToListAsync();

            if (Albums == null | Albums.Count() == 0)
                return NotFound();

            return Ok(Albums);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Album = await _context.Albums.FindAsync(id);

            if (Album == null)
                return NotFound();

            return Ok(Album);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> OfUser([FromRoute] int id)
        {
            IEnumerable<Album> Albums = await _context.Albums.Where(a => a.UserId == id).ToListAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Albums == null | Albums.Count() == 0)
                return NotFound();

            return Ok(Albums);
        }
    }
}