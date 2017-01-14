using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spootify.Context;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Repos
{
    public class AccountRepo
    {
        private IAccountContext context;

        public AccountRepo(IAccountContext context)
        {
            this.context = context;
        }

        public bool NewAccount(Account account)
        {
            return context.NewAccount(account);
        }

        public List<Account> GetAccount()
        {
            return context.GetAccounts();
        }

        public Account LoginAccount(string email, string password)
        {
            return context.LoginAccount(email, password);
        }
    }
}
