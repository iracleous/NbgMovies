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
    public class ListActorsModel : PageModel
    {
        private readonly NbgMovies.Model.MovieDbContext _context;

        public ListActorsModel(NbgMovies.Model.MovieDbContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; }

        public async Task OnGetAsync()
        {
            Actor = await _context.Actors.ToListAsync();
        }
    }
}
