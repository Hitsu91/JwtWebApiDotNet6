using JwtWebApi.DTOs.Character;
using JwtWebApi.DTOs.Weapon;
using JwtWebApi.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WeaponController : ControllerBase
{
    private readonly IWeaponService _weaponService;

    public WeaponController(IWeaponService weaponService)
    {
        _weaponService = weaponService;
    }

    [HttpPost]
    public async Task<ActionResult<CharacterResponseDto>> AddWeapon(WeaponRequestDto newWeapon)
    {
        return Ok(await _weaponService.AddWeapon(newWeapon));
    }
}