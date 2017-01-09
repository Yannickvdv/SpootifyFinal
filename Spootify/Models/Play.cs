using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spootify.Models
{
    public class Play
    {
        public int PlayID { get; set; }
        public int SongID { get; set; }
        public int AccountID { get; set; }
        public DateTime DateTime { get; set; }

        public Play(int playID, int songID, int AccountID, DateTime dateTime)
        {
            this.PlayID = playID;
            this.SongID = songID;
            this.AccountID = AccountID;
            this.DateTime = dateTime;
        }
    }
}