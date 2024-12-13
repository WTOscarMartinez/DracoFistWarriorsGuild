using System.ComponentModel.DataAnnotations;

namespace DracoFistWarriorsGuild.Models;

public class Quest
{
    public int QuestID {get; set;} // Primary Key

    public string ImgUrl {get; set;} = string.Empty;

    [Required]
    public string Type {get; set;} = string.Empty;

    [Required]
    public string Description {get; set;} = string.Empty;

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Reward {get; set;} = string.Empty;

    public string RewardImgURL {get; set;} = string.Empty;
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime PostedDate {get; set;}

    public string Status {get; set;} = string.Empty;

    [Display(Name = "Completed By")]
    public string? CompletedBy {get; set;} = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Completed On")]
    public DateTime CompletedOn {get; set;}

    public List<Member> Members {get; set;} = default!; // Navigation Property

    public override string ToString()
    {
        return $"{QuestID} {Type} {Status}";
    }
}