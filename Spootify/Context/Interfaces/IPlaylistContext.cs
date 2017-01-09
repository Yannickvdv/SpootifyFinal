using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Models;


namespace Spootify.Context.Interfaces
{
    public interface IPlaylistContext
    {
        List<Playlist> GetPlaylists(Account Account);
    }
}