﻿using System;
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

        public bool NewSong(Song song)
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
            return true;
        }

        public bool EditSong(Song song)
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

            return true;
        }

        public List<Song> GetAll()
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

        public List<Song> GetSongsAccount(Account Account)
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

        public List<Song> GetSongsPlaylist(Playlist Playlist)
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

        public List<Song> GetSongsGenre(int GenreID)
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

        public List<Song> GetSongsRecommended(Account account)
        {
            string query =
                "select top 10 s.* from Account a, Song s, Genre g, Song_Genre sg WHERE s.SongID = sg.SongID AND sg.GenreID = g.GenreID AND a.AccountID = @AccountID AND (a.FavGenre1 = g.GenreID OR a.FavGenre2 = g.GenreID OR a.FavGenre3 = g.GenreID) order by newid()";
            using (SqlConnection connection = Database.Connection)
            {
                List<Song> songs = new List<Song>();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@AccountID", account.AccountID));
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
