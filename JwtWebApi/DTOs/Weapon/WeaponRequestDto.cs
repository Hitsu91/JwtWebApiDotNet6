namespace JwtWebApi.DTOs.Weapon;

public class WeaponRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public Guid CharacterId { get; set; }
}