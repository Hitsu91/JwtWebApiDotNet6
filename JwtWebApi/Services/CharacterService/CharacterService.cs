using AutoMapper;
using JwtWebApi.Data;
using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public CharacterService(DataContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<Character> AddCharacter(CharacterRequestDto character)
    {
        var newCharacter = _mapper.Map<Character>(character);
        var savedCharacter = _ctx.Characters.Add(newCharacter);
        await _ctx.SaveChangesAsync();
        return savedCharacter.Entity;
    }

    public async Task<Character?> DeleteCharacter(Guid id)
    {
        var existingCharacter = await _ctx.Characters.FindAsync(id);
        if (existingCharacter is null)
        {
            return null;
        }
        _ctx.Characters.Remove(existingCharacter);
        await _ctx.SaveChangesAsync();
        return existingCharacter;
    }

    public async Task<Character?> GetCharacterById(Guid id)
    {
        return await _ctx.Characters.FindAsync(id);
    }

    public async Task<List<Character>> GetCharacters()
    {
        return await _ctx.Characters.ToListAsync();
    }

    public async Task<Character?> UpdateCharacter(Guid id, CharacterRequestDto character)
    {
        if (!await _ctx.Characters.AnyAsync(c => c.Id == id))
        {
            return null;
        }
        
        var toBeUpdatedCharacter = _mapper.Map<Character>(character);
        toBeUpdatedCharacter.Id = id;
        var updatedCharacter = _ctx.Characters.Update(toBeUpdatedCharacter);
        await _ctx.SaveChangesAsync();
        return updatedCharacter.Entity;
    }
}
