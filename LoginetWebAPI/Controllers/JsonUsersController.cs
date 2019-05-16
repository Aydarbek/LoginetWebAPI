using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Controllers
{

    [Route("loginetapi/[controller]/[action]")]
    [ApiController]
    public class JsonUsersController : ControllerBase
    {
        private IDataContext _dataContext;

        public JsonUsersController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [FormatFilter]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Users = _dataContext.Users;

            if (Users == null | Users.Count() == 0)
                return NotFound();

            return Ok(Users); 
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            User User = _dataContext.Users.FirstOrDefault(u => u.Id == id);            
            
            if (User == null)
                return NotFound();

            return Ok(User);
        }
    }
}
