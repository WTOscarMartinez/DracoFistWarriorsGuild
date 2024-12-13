using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DracoFistWarriorsGuild.Models;

namespace DracoFistWarriorsGuild.Pages_Quests
{
    public class EditModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;

        public EditModel(DracoFistWarriorsGuild.Models.AppDbContext context)
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

            var quest =  await _context.Quests!.FirstOrDefaultAsync(m => m.QuestID == id);
            if (quest == null)
            {
                return NotFound();
            }
            Quest = quest;

            var members = await _context.Members!
                .ToListAsync();

            ViewData["Members"] = new SelectList(members, "QuestID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Quest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestExists(Quest.QuestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuestExists(int id)
        {
            return _context.Quests!.Any(e => e.QuestID == id);
        }
    }
}
