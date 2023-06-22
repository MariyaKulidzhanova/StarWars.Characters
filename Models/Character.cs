using StarWars.Characters.Enums;

namespace StarWars.Characters.Models;

public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? BirthDate { get; set; }
    public string? Planet { get; set; }
    public Gender Gender { get; set; }
    public string? Race { get; set; }
    public decimal Height { get; set; }
    public string? HairColor { get; set; }
    public string? EyeColor { get; set; }
    public string? Description { get; set; }
    public string? Movies { get; set; }
}
