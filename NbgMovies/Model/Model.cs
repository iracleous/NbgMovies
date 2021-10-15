using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMovies.Model
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie> Movies { get; set; }

    }


    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Actor> Actors { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        ACTION, COMEDY, DOCUMENTARY, DRAMA, FINCTION, SCIFI
    }

}
