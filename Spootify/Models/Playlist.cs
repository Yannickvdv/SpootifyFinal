using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spootify.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public int AccountID { get; set; }
        public string Name { get; set; }

        public Playlist(int playlistID, int AccountID, string name)
        {
            this.PlaylistID = playlistID;
            this.AccountID = AccountID;
            this.Name = name;
        }
    }
}