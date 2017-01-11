using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spootify.Models;

namespace Spootify.Context.Interfaces
{
    public interface ISongContext
    {
        Song getSong(string songID);
        bool NewSong(Song song);
        bool EditSong(Song song);
        List<Song> GetAll();
        List<Song> GetSongsAccount(Account playlist);
        List<Song> GetSongsPlaylist(Playlist playlist);
        List<Song> GetSongsGenre(int genreID);
        List<Song> GetSongsRecommended(Account account);

    }
}
