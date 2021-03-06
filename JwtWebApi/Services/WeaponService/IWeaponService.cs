using JwtWebApi.DTOs.Character;
using JwtWebApi.DTOs.Weapon;

namespace JwtWebApi.Services.WeaponService;

public interface IWeaponService
{
    Task<CharacterResponseDto?> AddWeapon(WeaponRequestDto newWeapon);
}