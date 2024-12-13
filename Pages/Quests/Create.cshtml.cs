using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DracoFistWarriorsGuild.Models;
using Mono.TextTemplating;

namespace DracoFistWarriorsGuild.Pages_Quests
{
    public class CreateModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;

        public CreateModel(DracoFistWarriorsGuild.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quest Quest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Quest.ImgUrl = "img/default_quest.webp";
            Quest.RewardImgURL = "img/default_reward.webp";
            Quest.PostedDate = DateTime.Now;
            Quest.Status = "Not Started";
            Quest.CompletedBy = null;
            Quest.CompletedOn = default!;
            Quest.Members = new List<Member>();

            _context.Quests?.Add(Quest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
