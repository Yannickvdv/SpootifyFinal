using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Spootify.Context;
using Spootify.Context.Interfaces;
using Spootify.Models;


namespace Spootify.Context
{
    class SongSQLContext : ISongContext
    {

        public Song getSong(string SongID)
        {
            try
            {
                string query = "SELECT * FROM Song WHERE SongID = " + SongID;
                using (SqlConnection connection = Database.Connection)
                {
                    Song song = new Song();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        song = new Song(Convert.ToInt32(reader["SongID"]), Convert.ToString(reader["Song"]),
                                                  Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Duration"]),
                                                  Convert.ToString(reader["Picture"]), Convert.ToDateTime(reader["Date"]));
                    }
                    return song;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool NewSong(Song song)
        {
            try
            {
                string query =
                    "INSERT INTO Song (SongID, Song, Name, Duration, Picture, Date) values (@SongID, @Song, @Name, @Duration, @Picture, @Date);";
                using (SqlConnection Connection = Database.Connection)
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.Parameters.Add(new SqlParameter("SongID", song.SongID));
                    cmd.Parameters.Add(new SqlParameter("Song", song.SongURL));
                    cmd.Parameters.Add(new SqlParameter("Name", song.Name));
                    cmd.Parameters.Add(new SqlParameter("Duration", song.Duration));
                    cmd.Parameters.Add(new SqlParameter("Picture", song.PictureURL));
                    cmd.Parameters.Add(new SqlParameter("Date", song.Date));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool EditSong(Song song)
        {
            try
            {
                string query =
                    "UPDATE Song SET (SongID, Song, Name, Duration, Picture, Date) VALUES (@SongID1, @Song, @Name, @Duration, @Picture, @Date) WHERE SongID = @SongID2;";
                using (SqlConnection Connection = Database.Connection)
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.Parameters.Add(new SqlParameter("SongID1", song.SongID));
                    cmd.Parameters.Add(new SqlParameter("Song", song.SongURL));
                    cmd.Parameters.Add(new SqlParameter("Name", song.Name));
                    cmd.Parameters.Add(new SqlParameter("Duration", song.Duration));
                    cmd.Parameters.Add(new SqlParameter("Picture", song.PictureURL));
                    cmd.Parameters.Add(new SqlParameter("Date", song.Date));
                    cmd.Parameters.Add(new SqlParameter("SongID2", song));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Song> GetAll()
        {
            try
            {
                string query = "SELECT * FROM Song s";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Song> songs = new List<Song>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Song song = new Song(Convert.ToInt32(reader["SongID"]), Convert.ToString(reader["Song"]),
                            Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Duration"]),
                            Convert.ToString(reader["Picture"]), Convert.ToDateTime(reader["Date"]));
                        songs.Add(song);
                    }
                    return songs;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<Song> GetSongsAccount(Account Account)
        {
            try
            {
                string query =
                    "SELECT s.* FROM Song s, Musician_Song m, Account a WHERE s.SongID = m.SongID AND m.AccountID = a.AccountID AND a.AccountID =  @AccountID;";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Song> songs = new List<Song>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@AccountID", Account.AccountID));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Song song = new Song(Convert.ToInt32(reader["SongID"]), Convert.ToString(reader["Song"]),
                            Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Duration"]),
                            Convert.ToString(reader["Picture"]), Convert.ToDateTime(reader["Date"]));
                        songs.Add(song);
                    }
                    return songs;
                }
            }
            catch(Exception)
            {
                return null;
                
            }
        }
        public List<Song> GetSongsPlaylist(Playlist Playlist)
        {
            try
            {
                string query =
                    "SELECT s.* FROM Song s, Playlist_Song ps, Playlist p WHERE s.SongID = ps.SongID AND ps.PlaylistID = p.PlaylistID AND p.PlaylistID = @PlaylistID";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Song> songs = new List<Song>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@PlaylistID", Playlist.PlaylistID));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Song song = new Song(Convert.ToInt32(reader["SongID"]), Convert.ToString(reader["Song"]),
                            Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Duration"]),
                            Convert.ToString(reader["Picture"]), Convert.ToDateTime(reader["Date"]));
                        songs.Add(song);
                    }
                    return songs;
                }
            }
            catch (Exception)
            {
                return null;

            }


        }

        public List<Song> GetSongsGenre(string GenreID)
        {
      
                string query =
                    "SELECT s.* FROM Song s, Song_Genre sg, Genre g WHERE s.SongID = sg.SongID AND sg.GenreID = g.GenreID AND g.GenreID = @GenreID";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Song> songs = new List<Song>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@GenreID", GenreID));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Song song = new Song(Convert.ToInt32(reader["SongID"]), Convert.ToString(reader["Song"]),
                            Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Duration"]),
                            Convert.ToString(reader["Picture"]), Convert.ToDateTime(reader["Date"]));
                        songs.Add(song);
                    }
                    return songs;
                }
 
        }
    }
}
