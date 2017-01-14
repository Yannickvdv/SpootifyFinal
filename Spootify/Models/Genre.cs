using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Context;
using Spootify.Repos;

namespace Spootify.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public int ParentGenreID { get; set; }

        public List<Genre> GetSongs { get; set; }

        public List<Song> GetSongsGenre(int id)
        {
            SongRepo SongRepo = new SongRepo(new SongSQLContext());
            return SongRepo.GetSongsGenre(id);
        }

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