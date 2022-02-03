using System.Text.Json.Serialization;

namespace JwtWebApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
    Knight,
    Mage,
    Cleric,
}