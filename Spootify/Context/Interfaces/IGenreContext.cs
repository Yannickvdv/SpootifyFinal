using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Models;

namespace Spootify.Context.Interfaces
{
    public interface IGenreContext
    {
        Genre GetGenre(string GenreID);
        List<Genre> GetGenres();
        List<Genre> GetGenresLied(Song song);
        bool AddLiedGenre(string SongID, List<Genre> genres);
    }
}