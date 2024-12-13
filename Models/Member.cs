using System.ComponentModel.DataAnnotations;

namespace DracoFistWarriorsGuild.Models;

public class Member
{
    public int MemberID {get; set;} // Primary Key

    [Required]
    public string ImgUrl {get; set;} = string.Empty;

    [Required]
    [Display(Name = "Member Name")]
    [StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;
    
    [Required]
    public int Age {get; set;}

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Gender {get; set;} = string.Empty;

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Class {get; set;} = string.Empty;

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Race {get; set;} = string.Empty;

    public int? QuestID {get; set;} // Foreign Key
    public Quest Quest {get; set;} = default!; // Navigation Property
}