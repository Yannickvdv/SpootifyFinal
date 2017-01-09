using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Spootify.Context.Interfaces;
using Spootify.Models;

namespace Spootify.Context
{
    public class GenreSQLContext : IGenreContext
    {
        public List<Genre> GetGenres()
        {
   
                string query = "SELECT * FROM Genre;";
                using (SqlConnection connection = Database.Connection)
                {
                    List<Genre> Genres = new List<Genre>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ParentGenreID;
                        if (!Convert.IsDBNull(reader["ParentGenreID"]))
                        {
                            ParentGenreID = Convert.ToInt32(reader["ParentGenreID"]);
                        }
                        else
                        {
                            ParentGenreID = 0;
                        }

                        Genre Genre = new Genre(Convert.ToInt32(reader["GenreID"]), Convert.ToString(reader["Name"]), ParentGenreID);
                        Genres.Add(Genre);
                    }
                    return Genres;
                
            }

        }

        public List<Genre> GetGenresLied(Song song)
        {
            try
            {
                string query = "SELECT * FROM Genre g, Song_Genre sg, Song s WHERE g.GenreID = sg.GenreID AND sg.SongID = s.SongID AND s.SongID = " + song.SongID;
                using (SqlConnection connection = Database.Connection)
                {
                    List<Genre> Genres = new List<Genre>();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Genre Genre = new Genre(Convert.ToInt32(reader["GenreID"]), Convert.ToString(reader["Name"]),
                            Convert.ToInt32(reader["ParentGenreID"]));
                        Genres.Add(Genre);
                    }
                    return Genres;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Genre GetGenre(string GenreID)
        {
            try
            {
                string query = "SELECT * FROM Genre WHERE GenreID = " + GenreID;
                using (SqlConnection connection = Database.Connection)
                {
                    Genre genre = new Genre();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        genre = new Genre(Convert.ToInt32(reader["GenreID"]), Convert.ToString(reader["Name"]),
                            Convert.ToInt32(reader["ParentGenreID"]));
                    }
                    return genre;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}