using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Context
{
    public class PlaylistSQLContext : IPlaylistContext
    {
        public List<Playlist> GetPlaylists(Account Account)
        {
            try
            {
                string query = "SELECT * FROM Playlist WHERE AccountID =" + Account.AccountID;
                using (SqlConnection connection = Database.Connection)
                {
                    List<Playlist> playlists = new List<Playlist>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Playlist playlist = new Playlist(Convert.ToInt32(reader["PlaylistID"]), Convert.ToInt32(reader["AccountID"]),
                            Convert.ToString(reader["Name"]));
                        playlists.Add(playlist);
                    }
                    return playlists;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}