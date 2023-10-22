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
        public async Task<IActionResult> Create([FromBody] CharacterCreationDTO model)
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

        [HttpGet("retrieve")]
        public async Task<IActionResult> Retrieve()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            List<PlayerCharacter> characters = _playerCharacterService.GetByUserId(userId);

            return Ok(characters);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            bool isAllowed = _playerCharacterService.IsUserAllowedToModifyCharacter(userId, id);
            if (!isAllowed)
            {
                return Unauthorized("User does not have permission to perform this action");
            }

            bool success = _playerCharacterService.DeleteCharacter(id);
            if (!success)
            {
                return BadRequest("Character deletion failed");
            }

            return Ok("Character deleted successfully");
        }
    }
}
