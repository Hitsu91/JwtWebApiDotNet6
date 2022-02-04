using System.Security.Claims;
using AutoMapper;
using JwtWebApi.Data;
using JwtWebApi.DTOs.Character;
using JwtWebApi.DTOs.Weapon;
using JwtWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApi.Services.Weapon;

public class WeaponService : IWeaponService
{
    private readonly DataContext _ctx;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public WeaponService(DataContext ctx, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _ctx = ctx;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    
    public async Task<CharacterResponseDto?> AddWeapon(WeaponRequestDto newWeapon)
    {
        var character = await _ctx.Characters.FirstOrDefaultAsync(
            c => c.Id == newWeapon.CharacterId && c.User != null && c.User.Id == GetUserId());

        if (character is null)
        {
            return null;
        }
        
        var weapon = new Weapon
        {
            
        }
        
        return new CharacterResponseDto();
    }
    
    private Guid GetUserId() =>
        Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
}