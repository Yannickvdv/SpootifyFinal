using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Spootify.Models;
using Spootify.Context.Interfaces;

namespace Spootify.Repos
{
    class SongRepo
    {
        private ISongContext context;

        public SongRepo(ISongContext context)
        {
            this.context = context;
        }

        public Song GetSong(string songID)
        {
            return context.getSong(songID);
        }

        public bool NewSong(Song song)
        {
            return context.NewSong(song);
        }

        public bool EditSong(Song song)
        {
            return context.EditSong(song);
        }

        public List<Song> GetAll()
        {
            return context.GetAll();
        }

        public List<Song> GetSongsAccount(Account account)
        {
            return context.GetSongsAccount(account);
        }

        public List<Song> GetSongsPlaylist(Playlist playlist)
        {
            return context.GetSongsPlaylist(playlist);
        }

        public List<Song> GetSongsGenre(string genreID)
        {
            return context.GetSongsGenre(genreID);
        }
    }
}
