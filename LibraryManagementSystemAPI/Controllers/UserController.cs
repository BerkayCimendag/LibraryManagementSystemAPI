using LibraryManagementSystemAPI.AbstractServices;
using LibraryManagementSystemAPI.ConcreteServices;
using LibraryManagementSystemAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.SignIn(user);

            return Ok(user);
        }


        [HttpPost("getMyRentedBooks")]
        public async Task<IActionResult> GetMyRentedBooks(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var userBooks =  await _userService.GetMyRentedBooks(userId);

            return Ok(userBooks);
        }

        [HttpPost("returnRentedBook")]
        public async Task<IActionResult> ReturnRentedBook(int userId,int bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          await _userService.ReturnRentedBook(userId,bookId);

            return Ok();
        }
    }
}
