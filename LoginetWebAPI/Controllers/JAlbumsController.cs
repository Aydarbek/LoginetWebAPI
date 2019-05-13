using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LoginetWebAPI.Models;

namespace LoginetWebAPI.Controllers
{
    [Route("json/[controller]/[action]")]
    [ApiController]
    public class JAlbumsController : ControllerBase
    {
        readonly Uri AlbumsUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/albums");

        [HttpGet]
        [FormatFilter]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);
                IEnumerable<Album> Albums = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Album>>(AlbumsJson));

                if (Albums == null | Albums.Count() == 0)
                    return NotFound();

                return Ok(Albums);
            }
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);

                Album Album = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Album>>(AlbumsJson).FirstOrDefault(u => u.Id == id));

                if (Album == null)
                    return NotFound();

                return Ok(Album);
            }
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> OfUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);

                IEnumerable<Album> Albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(AlbumsJson).Where(a => a.UserId == id).ToList<Album>();

                if (Albums == null)
                    return NotFound();

                return Ok(Albums);
            }
        }
    }
}