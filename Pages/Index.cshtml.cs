using DracoFistWarriorsGuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DracoFistWarriorsGuild.Pages;

public class IndexModel : PageModel
{
    private readonly Models.AppDbContext _context;
    
    private readonly ILogger<IndexModel> _logger;

    public IList<Quest> Quest { get;set; } = default!;
    public IList<Member> Member { get;set; } = default!;

    public IndexModel(ILogger<IndexModel> logger, DracoFistWarriorsGuild.Models.AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        Quest = await _context.Quests!.ToListAsync();
        Member = await _context.Members!.ToListAsync();
    }
}
