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
        private readonly IDataContext _dataContext;

        public AlbumsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        [FormatFilter]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<AlbumModel> albumsModel = _dataContext.Albums.Select(a => new AlbumModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToList();
    
            if (albumsModel == null | albumsModel.Count() == 0)
                return NotFound();

            return Ok(albumsModel);
        }

        
        [HttpGet("{id}")]
        [FormatFilter]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Album album = _dataContext.Albums.FirstOrDefault(a => a.Id == id);
            AlbumModel albumModel = new AlbumModel
            {
                Id = album.Id,
                UserId = album.UserId,
                AlbumName = album.AlbumName,
                Description = album.Description
            };

            if (albumModel == null)
                return NotFound();

            return Ok(albumModel);
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public IActionResult OfUser(int id)
        {
            IEnumerable<AlbumModel> albumsModel = _dataContext.Albums.Where(a => a.UserId == id).Select(a => new AlbumModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (albumsModel == null | albumsModel.Count() == 0)
                return NotFound();

            return Ok(albumsModel);
        }
    }
}