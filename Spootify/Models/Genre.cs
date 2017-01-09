using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spootify.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public int ParentGenreID { get; set; }

        public Genre()
        {
            
        }

        public Genre(int genreID, string name, int parentGenreID)
        {
            this.GenreID = genreID;
            this.Name = name;
            this.ParentGenreID = parentGenreID;
        }

    }
}