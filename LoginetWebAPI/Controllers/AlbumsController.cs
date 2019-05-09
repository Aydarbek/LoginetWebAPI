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
    [Route("ef/[controller]/[action]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly DBContext _context;

        public AlbumsController(DBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [FormatFilter]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<AlbumDataModel> Albums = await _context.Albums.Select(a => new AlbumDataModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            if (Albums == null | Albums.Count() == 0)
                return NotFound();

            return Ok(Albums);
        }

        
        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<AlbumDataModel> Album = await _context.Albums.Where(a => a.Id == id).Select(a => new AlbumDataModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            if (Album == null)
                return NotFound();

            return Ok(Album);
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> OfUser([FromRoute] int id)
        {
            IEnumerable<AlbumDataModel> Albums = await _context.Albums.Where(a => a.UserId == id).Select(a => new AlbumDataModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Albums == null | Albums.Count() == 0)
                return NotFound();

            return Ok(Albums);
        }
    }
}