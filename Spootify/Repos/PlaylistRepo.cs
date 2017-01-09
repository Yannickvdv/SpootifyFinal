using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Repos
{
    public class PlaylistRepo
    {
        private IPlaylistContext context;

        public PlaylistRepo(IPlaylistContext context)
        {
            this.context = context;
        }

        public List<Playlist> GetPlaylists(Account account)
        {
            return context.GetPlaylists(account);
        }

    }
}