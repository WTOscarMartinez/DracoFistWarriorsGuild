using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DracoFistWarriorsGuild.Models;

namespace DracoFistWarriorsGuild.Pages_Members
{
    public class EditModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;

        public EditModel(DracoFistWarriorsGuild.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member =  await _context.Members!.FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }
            Member = member;

            var availableQuests = await _context.Quests!
                .Where(q => q.Status != "Completed")
                .ToListAsync();

            ViewData["QuestCurrent"] = new SelectList(availableQuests, "QuestID", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.MemberID))
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

        private bool MemberExists(int id)
        {
            return _context.Members!.Any(e => e.MemberID == id);
        }
    }
}