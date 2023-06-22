using StarWars.Characters.Enums;

namespace StarWars.Characters.Models
{
    public class CharacterVM
    {
        public CharacterVM() { }
        public CharacterVM(Character character) 
        {
            Id = character.Id;
            Name = character.Name;
            BirthDate = character.BirthDate;
            Planet = character.Planet;
            Gender = character.Gender;
            Race = character.Race;
            HairColor = character.HairColor;
            Height = character.Height;
            EyeColor = character.EyeColor;
            Description = character.Description;
            Movies = character.Movies?.Split(',').ToList();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BirthDate { get; set; }
        public string? Planet { get; set; }
        public Gender Gender { get; set; }
        public string? Race { get; set; }
        public int Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }
        public string? Description { get; set; }
        public List<string>? Movies { get; set; }
    }
}
