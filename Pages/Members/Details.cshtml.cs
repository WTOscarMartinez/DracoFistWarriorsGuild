using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DracoFistWarriorsGuild.Models;

namespace DracoFistWarriorsGuild.Pages_Members
{
    public class DetailsModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;

        public DetailsModel(DracoFistWarriorsGuild.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        [BindProperty]
        public List<Quest> QuestHistory {get; set;} = new List<Quest>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members!
                .Include(m => m.Quest)
                .FirstOrDefaultAsync(m => m.MemberID == id);

            if (member == null)
            {
                return NotFound();
            }

            Member = member;

            QuestHistory = await _context.Quests!
                .Where(q => q.Status == "Completed" && q.CompletedBy == member.Name)
                .ToListAsync();

            return Page();
        }
    }
}
