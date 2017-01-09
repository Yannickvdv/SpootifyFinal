using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spootify.Models;

namespace Spootify.Context.Interfaces
{
    public interface IPlayContext
    {
        bool NewPlay(Song song, Account account, DateTime dateTime);
        List<Play> GetPlays(Account account);

    }
}