    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spootify.Context;
    using Spootify.Models;
    using Spootify.Repos;

namespace Spootify.Tests
{
    [TestClass]
    public class ReposTEST
    {
        [TestMethod]
        public void GetAllGenresTest()
        {
            GenreRepo repo = new GenreRepo(new GenreSQLContext());
            Assert.IsTrue(repo.GetGenres().Count == 14);
        }

        [TestMethod]
        public void NewAccountTest()
        {
            AccountRepo repo = new AccountRepo(new AccountSQLContext());
            Assert.IsTrue(
                repo.NewAccount(new Account("Bert", "Wachtwoord", "Bert@Wachtwoord.nl", DateTime.Now,
                    "http://imgserv9.tcdn.nl/v1/KpTS0Ze81jIMYVAqjoRS2_GJNN8=/704x398/smart/http://metronieuws.tcdn.nl/field/image/f679b118fbe79ff2dff12334b02f6164-1462286545.jpg",
                    "NULL", "NULL", "NULL")));
        }
    }
}
