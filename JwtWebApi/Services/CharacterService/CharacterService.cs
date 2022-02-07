﻿using System.Security.Claims;
using AutoMapper;
using JwtWebApi.Data;
using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JwtWebApi.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IQueryable<Character> _characters;

    public CharacterService(DataContext ctx, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _ctx = ctx;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _characters = _ctx.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills);
    }

    public async Task<CharacterResponseDto> AddCharacter(CharacterRequestDto newCharacter)
    {
        var character = _mapper.Map<Character>(newCharacter);
        character.User = await _ctx.Users.FindAsync(GetUserId());
        
        var savedCharacter = _ctx.Characters.Add(character);
        
        await _ctx.SaveChangesAsync();
        return _mapper.Map<CharacterResponseDto>(savedCharacter.Entity);
    }

    public async Task<CharacterResponseDto?> DeleteCharacter(Guid id)
    {
        var existingCharacter = await _ctx.Characters.FirstOrDefaultAsync(
            c => c.User != null && c.Id == id && c.User.Id == GetUserId());
        if (existingCharacter is null)
        {
            return null;
        }
        _ctx.Characters.Remove(existingCharacter);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<CharacterResponseDto>(existingCharacter);
    }

    public async Task<CharacterResponseDto?> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        var character = await _characters
            .FirstOrDefaultAsync(
                c => c.Id == newCharacterSkill.CharacterId && c.User != null && c.User.Id == GetUserId());

        if (character is null)
        {
            return null;
        }

        var skill = await _ctx.Skills.FindAsync(newCharacterSkill.SkillId);

        if (skill is null)
        {
            return null;
        }
        
        character.Skills.Add(skill);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<CharacterResponseDto>(character);
    }

    public async Task<CharacterResponseDto?> GetCharacterById(Guid id)
    {
        var character = await _characters
            .FirstOrDefaultAsync(
            c => c.User != null && c.Id == id && c.User.Id == GetUserId());
        return _mapper.Map<CharacterResponseDto>(character);
    }

    public Task<List<CharacterResponseDto>> GetAllCharacters()
    {
        return _characters
            .Where(c => c.User != null && c.User.Id  == GetUserId())
            .Select(c => _mapper.Map<CharacterResponseDto>(c))
            .ToListAsync();
    }

    public async Task<CharacterResponseDto?> UpdateCharacter(Guid id, CharacterRequestDto updatedCharacter)
    {
        if (!await _ctx.Characters.AnyAsync(c => c.User != null && c.Id == id && c.User.Id == GetUserId()))
        {
            return null;
        }
        
        var toBeUpdatedCharacter = _mapper.Map<Character>(updatedCharacter);
        toBeUpdatedCharacter.Id = id;
        var character = _ctx.Characters.Update(toBeUpdatedCharacter);
        await _ctx.SaveChangesAsync();
        return _mapper.Map<CharacterResponseDto>(character.Entity);
    }
    
    

    private Guid GetUserId() =>
        Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
}
