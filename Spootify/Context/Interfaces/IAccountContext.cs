using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spootify.Models;

namespace Spootify.Context.Interfaces
{
    public interface IAccountContext
    {
        bool NewAccount(Account Account);
        List<Account> GetAccounts();
        Account LoginAccount(string Email, string Password);
    }
}
