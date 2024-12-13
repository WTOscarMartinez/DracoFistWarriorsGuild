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
    public class IndexModel : PageModel
    {
        private readonly DracoFistWarriorsGuild.Models.AppDbContext _context;
        // Paging support
        // PageNum is the current page number we are on
        // PageSize is how many records will be displayed per page. 
        // PageNum needs BindProperty because the user decides which page we are on.
        // The user selects the page number
        // SupportsGet = true allows us to pass the PageNum through the URL with an HTTP Get Parameter 
        // This is necessary, because page numbers are not passed through normal forms
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 8;
        public int TotalPages {get; set;}
        
        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        [BindProperty(SupportsGet =  true)]
        public string CurrentSearch {get; set;} = string.Empty;
     
        public IndexModel(DracoFistWarriorsGuild.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Members!
                .Include(m => m.Quest).ToListAsync();

            var query = _context.Members!.Include(m => m.Quest).Select(m => m);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(m => m.Name.ToUpper().Contains(CurrentSearch.ToUpper()) || m.Class.ToUpper().Contains(CurrentSearch.ToUpper())|| m.Race.ToUpper().Contains(CurrentSearch.ToUpper())|| m.Gender.ToUpper().Contains(CurrentSearch.ToUpper()));
            }
            TotalPages = (int)Math.Ceiling(_context.Members!.Count() / (double)PageSize);
    
            Member = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }
    }
}
