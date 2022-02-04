using JwtWebApi.Models;

namespace JwtWebApi.DTOs.Character;

public class CharacterResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int HitPoints { get; set; } = 100;

    public int Strength { get; set; } = 10;

    public int Defence { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = default;
}