using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UntitledRPG.DTOs;
using UntitledRPG.Models;
using UntitledRPG.Services;

namespace UntitledRPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IPlayerCharacterService _playerCharacterService;

        public CharacterController(IPlayerCharacterService playerCharacterService)
        {
            _playerCharacterService = playerCharacterService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CharacterCreation model)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            bool success = _playerCharacterService.CreateCharacter(model, userId);

            if (!success)
            {
                return BadRequest("Character creation failed");
            }
            
            return Ok("Character created successfully");
        }
    }
}
