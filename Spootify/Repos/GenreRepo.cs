using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Repos
{
    class GenreRepo
    {
        private IGenreContext context;

        public GenreRepo(IGenreContext context)
        {
            this.context = context;
        }
        
        public List<Genre> GetGenres()
        {
            return context.GetGenres();
        }

        public List<Genre> GetGenresLied(Song song)
        {
            return context.GetGenresLied(song);
        }

        public Genre GetGenre(string GenreID)
        {
            return context.GetGenre(GenreID);
        }
    }
}