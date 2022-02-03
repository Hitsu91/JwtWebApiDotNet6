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
    private readonly ICharacterService characterService;
    private readonly ILogger<CharacterController> logger;

    public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger)
    {
        this.characterService = characterService;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAll()
    {
        return Ok(await characterService.GetCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetById([FromRoute] Guid id)
    {
        var character = await characterService.GetCharacterById(id);
        if (character is null)
        {
            return NotFound();
        }
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> Add([FromBody] CharacterRequestDto character)
    {
        return Ok(await characterService.AddCharacter(character));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Character>> Update([FromRoute] Guid id, CharacterRequestDto character)
    { 
        var updatedCharacter = await characterService.UpdateCharacter(id, character);
        if (updatedCharacter is null)
        {
            return NotFound();
        }

        return Ok(updatedCharacter);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> DeleteById([FromRoute] Guid id)
    {
        var deletedCharacter = await characterService.DeleteCharacter(id);
        if (deletedCharacter is null)
        {
            return NotFound();
        }

        return Ok(deletedCharacter);
    }

}
