using System.ComponentModel.DataAnnotations;

namespace StarWars.Characters.Enums;

public enum Gender
{
    [Display(Name="Мужской")]
    Male,
    [Display(Name="Женский")]
    Female
}
