using JwtWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace JwtWebApi.DTOs.Character;

public class CharacterRequestDto
{
    public string Name { get; set; } = string.Empty;

    public int HitPoints { get; set; } = default;

    public int Strength { get; set; } = default;

    public int Defence { get; set; } = default;

    public int Intelligence { get; set; } = default;

    public RpgClass Class { get; set; } = default;
}
