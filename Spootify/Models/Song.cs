using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spootify.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string SongURL { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string PictureURL { get; set; }

        private DateTime date;
        public DateTime Date
        {
            get { return date.Date; }
            set { date = value; }
        }

        public Song()
        {
            
        }
        public Song(int SongID, string SongURL, string Name, int Duration, string PictureURL, DateTime Date)
        {
            this.SongID = SongID;
            this.SongURL = SongURL;
            this.Name = Name;
            this.Duration = Duration;
            this.PictureURL = PictureURL;
            this.Date = Date;
        }
    }
}
