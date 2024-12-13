using Microsoft.EntityFrameworkCore;

namespace DracoFistWarriorsGuild.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (!context.Quests!.Any())
        {
            context.Quests!.AddRange(
                new Quest { ImgUrl = "img/quest1.webp", Type = "Kill", Description = "Slay the Demonlord of the Abyssal Fortress and bring back his infernal crown.", Reward = "5000 gold pieces and a legendary artifact", RewardImgURL = "img/reward1.webp", PostedDate = DateTime.Parse("2024-12-10"), Status = "Active", CompletedBy = null!, CompletedOn = default! },
                new Quest { ImgUrl = "img/quest2.webp", Type = "Escort", Description = "Escort Princess Aelindra of the High Elves to the neighboring kingdom through the Shadowed Peaks.", Reward = "2000 gold pieces and royal favor", RewardImgURL = "img/reward2.webp", PostedDate = DateTime.Parse("2024-11-25"), Status = "Not Started", CompletedBy = null!, CompletedOn = default! },
                new Quest { ImgUrl = "img/quest3.webp", Type = "Fetch", Description = "Retrieve the Staff of the Forgotten Seers from the Sunken Ruins of Zekthar.", Reward = "3000 gold pieces and a rare spell scroll", RewardImgURL = "img/reward3.webp", PostedDate = DateTime.Parse("2024-12-01"), Status = "Active", CompletedBy = null!, CompletedOn = default! },
                new Quest { ImgUrl = "img/quest4.webp", Type = "Delivery", Description = "Deliver the Sacred Tome of Ancients to the monastery atop the Crystal Spire.", Reward = "2500 gold pieces and a divine blessing", RewardImgURL = "img/reward4.webp", PostedDate = DateTime.Parse("2024-11-20"), Status = "Active", CompletedBy = null!, CompletedOn = default! },
                new Quest { ImgUrl = "img/quest5.webp", Type = "Kill", Description = "Assassinate the Orc Warlord Kargath Bloodmaw, who has rallied tribes against the kingdom.", Reward = "4000 gold pieces and a bounty hunter's badge", RewardImgURL = "img/reward5.webp", PostedDate = DateTime.Parse("2024-12-05"), Status = "Active", CompletedBy = null!, CompletedOn = default! },
                new Quest { ImgUrl = "img/quest6.webp", Type = "Escort", Description = "Guard the caravan carrying the Crown Jewels of Larethion through the Bandit Lands.", Reward = "3500 gold pieces and a jeweled amulet", RewardImgURL = "img/reward6.webp", PostedDate = DateTime.Parse("2024-11-11"), Status = "Completed", CompletedBy = "Thrug", CompletedOn = DateTime.Parse("2024-11-18") }
            );
            context.SaveChanges();
        }

        if (!context.Members!.Any())
        {
            context.Members!.AddRange(
                new Member { ImgUrl = "img/eryndor.webp", Name = "Eryndor", Age = 130, Gender = "Male", Class = "Archer", Race = "Elven", QuestID = 1 },
                new Member { ImgUrl = "img/tharok.webp", Name = "Tharok", Age = 45, Gender = "Male", Class = "Barbarian", Race = "Orc", QuestID = 4 },
                new Member { ImgUrl = "img/brynna.webp", Name = "Brynna", Age = 27, Gender = "Female", Class = "Sorcerer", Race = "Human", QuestID = 5 },
                new Member { ImgUrl = "img/durgrim.webp", Name = "Durgrim", Age = 200, Gender = "Male", Class = "Fighter", Race = "Dwarven", QuestID = 3 },
                new Member { ImgUrl = "img/liriel.webp", Name = "Liriel", Age = 115, Gender = "Female", Class = "Cleric", Race = "Elven", QuestID = 3 },
                new Member { ImgUrl = "img/grashnak.webp", Name = "Grashnak", Age = 38, Gender = "Male", Class = "Fighter", Race = "Orc", QuestID = 1 },
                new Member { ImgUrl = "img/kaelen.webp", Name = "Kaelen", Age = 33, Gender = "Male", Class = "Archer", Race = "Human", QuestID = 4 },
                new Member { ImgUrl = "img/morlin.webp", Name = "Morlin", Age = 120, Gender = "Male", Class = "Sorcerer", Race = "Dwarven", QuestID = 1 },
                new Member { ImgUrl = "img/sylvara.webp", Name = "Sylvara", Age = 140, Gender = "Female", Class = "Archer", Race = "Elven", QuestID = 3 },
                new Member { ImgUrl = "img/varek.webp", Name = "Varek", Age = 39, Gender = "Male", Class = "Barbarian", Race = "Human", QuestID = 1 },
                new Member { ImgUrl = "img/thrug.webp", Name = "Thrug", Age = 42, Gender = "Male", Class = "Cleric", Race = "Orc", QuestID = 5 },
                new Member { ImgUrl = "img/faldin.webp", Name = "Faldin", Age = 74, Gender = "Male", Class = "Barbarian", Race = "Dwarven", QuestID = 4 },
                new Member { ImgUrl = "img/arwen.webp", Name = "Arwen", Age = 125, Gender = "Female", Class = "Fighter", Race = "Elven", QuestID = 5 }
            );
            context.SaveChanges();
        }
    }
}