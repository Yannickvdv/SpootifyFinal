using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Context
{
    public class PlaySQLContext : IPlayContext
    {
        public List<Play> GetPlays(Account account)
        {
            try
            {
                string query = "SELECT * FROM Play WHERE AccountID = ;" + account.AccountID;
                using (SqlConnection connection = Database.Connection)
                {
                    List<Play> Plays = new List<Play>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Play play = new Play(Convert.ToInt32(reader["PlayID"]), Convert.ToInt32(reader["SongID"]), Convert.ToInt32(reader["AccountID"]),
                            Convert.ToDateTime(reader["DateTime"]));
                        Plays.Add(play);
                    }
                    return Plays;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool NewPlay(Song song, Account account, DateTime dateTime)
        {
            try
            {
                string query =
                    "INSERT INTO Play (SongID, AccountID, DateTime) values (@SongID, @AccountID, @DateTime);";
                using (SqlConnection Connection = Database.Connection)
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.Parameters.Add(new SqlParameter("@SongID", song.SongID));
                    cmd.Parameters.Add(new SqlParameter("@AccountID", account.AccountID));
                    cmd.Parameters.Add(new SqlParameter("@DateTime", dateTime));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}