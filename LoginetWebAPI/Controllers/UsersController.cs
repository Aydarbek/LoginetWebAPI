using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Controllers
{

    [Route("ef/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataContext _dataContext;

        public UsersController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [FormatFilter]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            IEnumerable<UserModel> Users = await _dataContext.GetAllUsers();

            if (Users == null | Users.Count() == 0)
                return NotFound();

            return Ok(Users); 
        }


        [HttpGet("{id}")]
        [FormatFilter]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UserModel User = await _dataContext.GetUser(id);            
            
            if (User == null)
                return NotFound();

            return Ok(User);
        }



    }
}
