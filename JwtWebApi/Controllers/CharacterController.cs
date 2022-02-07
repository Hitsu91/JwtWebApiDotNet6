using System.Security.Claims;
using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;
using JwtWebApi.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly ILogger<CharacterController> _logger;

    public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger)
    {
        _characterService = characterService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAll()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Character>> GetById([FromRoute] Guid id)
    {
        var character = await _characterService.GetCharacterById(id);
        if (character is null)
        {
            return NotFound($"You don't have a character with id {id}");
        }
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> Add([FromBody] CharacterRequestDto character)
    {
        return Ok(await _characterService.AddCharacter(character));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Character>> Update([FromRoute] Guid id, CharacterRequestDto character)
    { 
        var updatedCharacter = await _characterService.UpdateCharacter(id, character);
        if (updatedCharacter is null)
        {
            return NotFound();
        }

        return Ok(updatedCharacter);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Character>> DeleteById([FromRoute] Guid id)
    {
        var deletedCharacter = await _characterService.DeleteCharacter(id);
        if (deletedCharacter is null)
        {
            return NotFound();
        }

        return Ok(deletedCharacter);
    }

    [HttpPost("Skill")]
    public async Task<ActionResult<CharacterResponseDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSKill)
    {
        return Ok(await _characterService.AddCharacterSkill(newCharacterSKill));
    }

}
