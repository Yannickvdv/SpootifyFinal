using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Repos
{
    public class PlayRepo
    {
        private IPlayContext context;

        public PlayRepo(IPlayContext context)
        {
            this.context = context;
        }

        public bool NewPlay(Song song, Account account, DateTime dateTime)
        {
            return context.NewPlay(song, account, dateTime);
        }

        public List<Play> GetPlays(Account account)
        {
            return context.GetPlays(account);
        }
    }
}