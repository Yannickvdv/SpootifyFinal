using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Spootify.Models
{
    [Serializable]
    public class Account
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private DateTime Date;
        public DateTime date
        {
            get { return Date.Date; }
            set { Date = value; }
        }
        public string ProfilePictureURL { get; set; }
        public string FavGenre1 { get; set; }
        public string FavGenre2 { get; set; }
        public string FavGenre3 { get; set; }

        public Account()
        {
            
        }
        public Account(string Name, string Password, string Email, DateTime Date,
            string ProfilePictureURL, string FavGenre1, string FavGenre2, string FavGenre3)
        {
            this.AccountID = AccountID;
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Date = Date;
            this.ProfilePictureURL = ProfilePictureURL;
            this.FavGenre1 = FavGenre1;
            this.FavGenre2 = FavGenre2;
            this.FavGenre3 = FavGenre3;
        }

        public Account(int AccountID, string Name, string Password, string Email, DateTime Date,
            string ProfilePictureURL, string FavGenre1, string FavGenre2, string FavGenre3)
        {
            this.AccountID = AccountID;
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Date = Date;
            this.ProfilePictureURL = ProfilePictureURL;
            this.FavGenre1 = FavGenre1;
            this.FavGenre2 = FavGenre2;
            this.FavGenre3 = FavGenre3;
        }
    }
}
