using JwtWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace JwtWebApi.DTOs.Character;

public class CharacterRequestDto
{
    [Required, MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 1000)]
    public int HitPoints { get; set; } = default;

    [Range(1, 1000)]
    public int Strenght { get; set; } = default;

    [Range(1, 1000)]
    public int Defence { get; set; } = default;

    [Range(1, 1000)]
    public int Intelligence { get; set; } = default;

    [Required]
    public RpgClass Class { get; set; } = default;
}
