using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UntitledRPG.Models;
using UntitledRPG.Services;

namespace UntitledRPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameStateController : ControllerBase
    {
        private readonly IGameStateService _gameStateService;

        public GameStateController(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            GameState? gameState = _gameStateService.GetGameState(userId);

            if (gameState != null)
            {
                return BadRequest("Game state already exists");
            }

            bool success = _gameStateService.CreateGameState(userId);

            if (!success)
            {
                return BadRequest("Game state creation failed");
            }

            return Ok("Game state created successfully");
        }

        [HttpGet("retrieve")]
        public async Task<IActionResult> Retrieve()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            GameState? gameState = _gameStateService.GetGameState(userId);

            if (gameState == null)
            {
                return BadRequest("Game state retrieval failed");
            }

            return Ok(gameState);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] GameState gameState)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            bool success = _gameStateService.UpdateGameState(gameState);

            if (!success)
            {
                return BadRequest("Game state update failed");
            }

            return Ok("Game state updated successfully");
        }

        [HttpPut("addtoparty/{characterId}")]
        public async Task<IActionResult> AddToParty(int characterId)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            bool success = _gameStateService.AddCharacterToParty(userId, characterId);

            if (!success)
            {
                return BadRequest("Character addition to party failed");
            }

            return Ok("Character added to party successfully");
        }

        [HttpPut("removefromparty/{characterId}")]
        public async Task<IActionResult> RemoveFromParty(int characterId)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid user");
            }

            bool success = _gameStateService.RemoveCharacterFromParty(userId, characterId);

            if (!success)
            {
                return BadRequest("Character removal from party failed");
            }

            return Ok("Character removed from party successfully");
        }
    }
}
