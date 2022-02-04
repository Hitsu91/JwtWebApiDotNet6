using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;
using JwtWebApi.Services.CharacterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers;

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
        return Ok(await _characterService.GetCharacters());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Character>> GetById([FromRoute] Guid id)
    {
        var character = await _characterService.GetCharacterById(id);
        if (character is null)
        {
            return NotFound();
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

}
