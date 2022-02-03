using AutoMapper;
using JwtWebApi.Data;
using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly DataContext ctx;
    private readonly IMapper mapper;

    public CharacterService(DataContext ctx, IMapper mapper)
    {
        this.ctx = ctx;
        this.mapper = mapper;
    }

    public async Task<Character> AddCharacter(CharacterRequestDto character)
    {
        var newCharacter = mapper.Map<Character>(character);
        var savedCharacter = ctx.Characters.Add(newCharacter);
        await ctx.SaveChangesAsync();
        return savedCharacter.Entity;
    }

    public async Task<Character?> DeleteCharacter(Guid id)
    {
        var existingCharacter = await ctx.Characters.FindAsync(id);
        if (existingCharacter is null)
        {
            return null;
        }
        ctx.Characters.Remove(existingCharacter);
        await ctx.SaveChangesAsync();
        return existingCharacter;
    }

    public async Task<Character?> GetCharacterById(Guid id)
    {
        return await ctx.Characters.FindAsync(id);
    }

    public async Task<List<Character>> GetCharacters()
    {
        return await ctx.Characters.ToListAsync();
    }

    public async Task<Character?> UpdateCharacter(Guid id, CharacterRequestDto character)
    {
        if (!await ctx.Characters.AnyAsync(c => c.Id == id))
        {
            return null;
        }
        
        var toBeUpdatedCharacter = mapper.Map<Character>(character);
        toBeUpdatedCharacter.Id = id;
        var updatedCharacter = ctx.Characters.Update(toBeUpdatedCharacter);
        await ctx.SaveChangesAsync();
        return updatedCharacter.Entity;
    }
}
