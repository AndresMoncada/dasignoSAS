using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dasignoSAS.Context;
using dasignoSAS.Models;
using dasignoSAS.Items.Commands.UserFHandler.Params;
using MediatR;

namespace dasignoSAS.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UsersController(AppDbContext context) : BaseController
    {
        private readonly AppDbContext _context = context;

        // Get all users 
        [Route("getAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Get user for id
        [Route("getUserById/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>?> GetUserById(int id)
        {
            var user = await Mediator.Send(new UserQueryByIdCommand { Id = id});
            return user;
        }

        // Get user by name or lastname
        [Route("getUserByNombreApellido")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByNombreApellido([FromQuery] UserQueryByNombreApellidoCommand request)
        {
            var users = await Mediator.Send(request);
            return Ok(users);
        }

        // Update user
        [Route("updateUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateCommand request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        // Create user
        [Route("createUser")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostUser(UserInsCommand request)
        {
            var result = await Mediator.Send(request);
            return result ;
        }

        // Delete user
        [Route("deleteUser/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            await Mediator.Send(new UserDelCommand { Id = id });
            return NoContent();
        }
    }
}
