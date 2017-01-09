using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Context
{
    class AccountSQLContext : IAccountContext
    {
        public bool NewAccount(Account Account)
        {
            try
            {
            string query =
                "INSERT INTO Account ( Name, Password, Email, Date, ProfilePicture, FavGenre1, FavGenre2, FavGenre3) VALUES (@Name, @Password, @Email, @Date, @ProfilePicture, @FavGenre1, @FavGenre2, @FavGenre3);";
            using (SqlConnection Connection = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, Connection);
                cmd.Parameters.Add(new SqlParameter("@Name", Account.Name));
                cmd.Parameters.Add(new SqlParameter("@Password", Account.Password));
                cmd.Parameters.Add(new SqlParameter("@Email", Account.Email));
                cmd.Parameters.Add(new SqlParameter("@Date", Account.date));
                cmd.Parameters.Add(new SqlParameter("@ProfilePicture", Account.ProfilePictureURL));
                cmd.Parameters.Add(new SqlParameter("@FavGenre1", Account.FavGenre1));
                cmd.Parameters.Add(new SqlParameter("@FavGenre2", Account.FavGenre2));
                cmd.Parameters.Add(new SqlParameter("@FavGenre3", Account.FavGenre3));
                cmd.ExecuteNonQuery();
            }
            return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Account> GetAccounts()
        {
            try
            {
                string query = "SELECT * FROM Account;";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Account> Accounts = new List<Account>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Account Account = new Account(Convert.ToInt32(reader["AccountID"]),
                            Convert.ToString(reader["Name"]), Convert.ToString(reader["Password"]),
                            Convert.ToString(reader["Email"]), Convert.ToDateTime(reader["Date"]),
                            Convert.ToString(reader["ProfilePicture"]), Convert.ToString(reader["FavGenre1"]),
                            Convert.ToString(reader["FavGenre2"]), Convert.ToString(reader["FavGenre3"]));
                        Accounts.Add(Account);
                    }
                    return Accounts;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }


        public Account LoginAccount(string Email, string Password)
        {
            try
            {
                using (Database.Connection)
                {
                    SqlCommand cmd = new SqlCommand("AccountLogin", Database.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    Account account = new Account();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            account.AccountID = Convert.ToInt32(reader["AccountID"]);
                            account.Name = Convert.ToString(reader["Name"]);
                            account.Password = Convert.ToString(reader["Password"]);
                            account.Email = Convert.ToString(reader["Email"]);
                            account.date = Convert.ToDateTime(reader["Date"]);
                            account.ProfilePictureURL = Convert.ToString(reader["ProfilePicture"]);
                            account.FavGenre1 = Convert.ToString(reader["FavGenre1"]);
                            account.FavGenre2 = Convert.ToString(reader["FavGenre2"]);
                            account.FavGenre3 = Convert.ToString(reader["FavGenre3"]);
                        }
                    }
                    return account;
                }

            }
            catch (Exception)
            {
                return null;
            } 

        }
    }
}
