using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NbgMovies.Model;

namespace NbgMovies.Pages
{
    public class IndexModelMovies : PageModel
    {
        private readonly NbgMovies.Model.MovieDbContext _context;

        public IndexModelMovies(NbgMovies.Model.MovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.Include(movie=> movie.Actors).ToListAsync();
        }
    }
}
