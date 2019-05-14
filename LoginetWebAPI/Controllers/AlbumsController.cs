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
        private readonly IDataContext _context;

        public AlbumsController(IDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [FormatFilter]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<AlbumModel> Albums = await _context.GetAllAlbums();

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

            AlbumModel Album = await _context.GetAlbum(id);

            if (Album == null)
                return NotFound();

            return Ok(Album);
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> OfUser([FromRoute] int id)
        {
            IEnumerable<AlbumModel> Albums = await _context.GetAlbumsOfUser(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Albums == null | Albums.Count() == 0)
                return NotFound();

            return Ok(Albums);
        }
    }
}