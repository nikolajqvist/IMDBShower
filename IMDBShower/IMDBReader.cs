using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBShower
{
    public class IMDBReader
    {
        private readonly string _connectionString;

        public IMDBReader()
        {
            _connectionString = "Server=localhost;Database=IMDB;integrated security=True;TrustServerCertificate=True; Connection timeout = 600;";
        }
        public List<Titles> SearchMovie(string search)
        {
            List<Titles> list = new List<Titles>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "exec SearchMovies @SearchTerm = @search";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@search", search);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Titles titles = new Titles()
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        PrimaryTitle = reader.IsDBNull(1) ? null : reader.GetString(1),
                        StartYear = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                        RunTimeMinutes = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                        TitleTypeId = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Genres = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };

                    list.Add(titles);
                }
                return list;
            }
        }

        public List<Person> SearchPerson(string search)
        {
            List<Person> list = new List<Person>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "exec SearchPeople @SearchTerm = @search";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@search", search);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person()
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        PrimaryName = reader.IsDBNull(1) ? null : reader.GetString(1),
                        BirthYear = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                        DeathYear = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                        Professions = reader.IsDBNull(4) ? null : reader.GetString(4),
                    };

                    list.Add(person);
                }
                return list;
            }
        }

        public void AddMovie(string primaryTitle, bool? isAdult, int? startYear, int? endYear, int? runTimeMinutes, int? titleTypeId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("AddMovie", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrimaryTitle", primaryTitle);
                    cmd.Parameters.AddWithValue("@IsAdult", (object?)isAdult ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartYear", (object?)startYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndYear", (object?)endYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RunTimeMinutes", (object?)runTimeMinutes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TitleTypeId", (object?)titleTypeId ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddPerson(string primaryName, int? birthYear, int? deathYear)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("AddPerson", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrimaryName", primaryName);
                    cmd.Parameters.AddWithValue("@BirthYear", (object?)birthYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DeathYear", (object?)deathYear ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateMovie(int? id, string? primaryTitle, bool? isAdult, int? startYear, int? endYear, int? runTimeMinutes)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("UpdateMovie", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", (object?)id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrimaryTitle", (object?)primaryTitle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAdult", (object?)isAdult ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartYear", (object?)startYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndYear", (object?)endYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RunTimeMinutes", (object?)runTimeMinutes ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteMovie(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("DeleteMovie", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
