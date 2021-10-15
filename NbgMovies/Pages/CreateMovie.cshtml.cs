using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NbgMovies.Model;

namespace NbgMovies.Pages
{
    public class CreateModelMovie : PageModel
    {
        private readonly NbgMovies.Model.MovieDbContext _context;

        public CreateModelMovie(NbgMovies.Model.MovieDbContext context)
        {
            _context = context;
        }

        [BindProperty] public List<int> ActorIds { get; set; }
        public List<SelectListItem> ActorSelectList { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            ActorSelectList = await
                _context.Actors.Select(actor => new SelectListItem()
                { Value = actor.Id.ToString(), Text = actor.ToString() }).ToListAsync();
       
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Movie.Actors = await _context.Actors.Where(a => ActorIds.Contains(a.Id)).ToListAsync();


            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListMovies");
        }
    }
}
