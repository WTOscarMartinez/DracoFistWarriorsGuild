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
        public int PageSize {get; set;} = 4;
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

        public IList<Quest> Quest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Quest = await _context.Quests!.ToListAsync();

            var query = _context.Quests!.Include(q => q.Members).Select(q => q);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(q => q.Description.ToUpper().Contains(CurrentSearch.ToUpper()) || q.Type.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "des_asc":
                    query = query.OrderBy(q => q.Description);
                    break;
                case "des_desc":
                    query = query.OrderByDescending(q => q.Description);
                    break;
                case "date_asc":
                    query = query.OrderBy(q => q.PostedDate);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(q => q.PostedDate);
                    break;
                case "status_asc":
                    query = query.OrderBy(q => q.Status);
                    break;
                case "status_desc":
                    query = query.OrderByDescending(q => q.Status);
                    break;
            }
            TotalPages = (int)Math.Ceiling(_context.Quests!.Count() / (double)PageSize);
    
            Quest = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        
        }
    }
}
