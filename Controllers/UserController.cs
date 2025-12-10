using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using DataAccess.Models;

namespace TimeResourceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAll() { return Ok(await _userService.GetAll()); }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) { return Ok(await _userService.GetById(id)); }

        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            await _userService.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User model)
        {
            await _userService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
