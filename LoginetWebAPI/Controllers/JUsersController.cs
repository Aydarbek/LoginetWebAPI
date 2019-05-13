using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginetWebAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace LoginetWebAPI.Controllers
{
    [Route("json/[controller]/[action]")]
    [ApiController]
    public class JUsersController : ControllerBase
    {
        readonly Uri UsersUri = new Uri ("https://my-json-server.typicode.com/Aydarbek/MyJSON/users");

        [HttpGet]
        [FormatFilter]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (HttpClient client = new HttpClient())
            {
                string UsersJson = await client.GetStringAsync(UsersUri);
                IEnumerable<User> Users = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(UsersJson));

                if (Users == null | Users.Count() == 0)
                    return NotFound();

                return Ok(Users);
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
                string UsersJson = await client.GetStringAsync(UsersUri);

                User User = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(UsersJson).FirstOrDefault(u => u.Id == id));

                if (User == null)
                    return NotFound();

                return Ok(User);
            }
        }

    }
}