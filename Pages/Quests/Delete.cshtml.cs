using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DracoFistWarriorsGuild.Models;

namespace DracoFistWarriorsGuild.Pages_Quests
{
    public class DeleteModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;

        public DeleteModel(DracoFistWarriorsGuild.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quest Quest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests!.FirstOrDefaultAsync(m => m.QuestID == id);

            if (quest is not null)
            {
                Quest = quest;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests!.FindAsync(id);
            if (quest != null)
            {
                Quest = quest;
                _context.Quests.Remove(Quest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
