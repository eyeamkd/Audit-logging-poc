using Microsoft.AspNetCore.Mvc;

namespace AuditLoggerPoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    { 
        private readonly IUserService _userService;
        public UserController( IUserService userService ) 
        { 
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpPost]
        public async Task<User> AddUser([FromBody] User user)
        {
            return await _userService.AddUser(user);
        }

        [HttpPut]
        public async Task<User> UpdateUser([FromBody] User updatedUser)
        {
            return await _userService.UpdateUser(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser([FromRoute] Guid id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
