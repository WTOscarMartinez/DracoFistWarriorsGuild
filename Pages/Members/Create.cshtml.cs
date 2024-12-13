using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DracoFistWarriorsGuild.Models;

namespace DracoFistWarriorsGuild.Pages_Members
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
        ViewData["QuestID"] = new SelectList(_context.Quests, "QuestID", "Description");
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Member.Quest = null!;
            _context.Members!.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
