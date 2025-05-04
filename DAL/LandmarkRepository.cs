using Microsoft.Data.SqlClient;
using MyMvcApp.Models;
using System.Collections.Generic;

namespace MyMvcApp.DAL
{
    public class LandmarkRepository  : Landmark
    {
        //private readonly string _connectionString;

        private readonly string _connectionString;

        public LandmarkRepository(string connectionString)
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=History;Integrated Security=True;";
        }

        public List<Landmark> GetAllLandmarks()
        {
            var landmarks = new List<Landmark>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT Id, Name, Description, Location, YearEstablished FROM Landmarks";
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                landmarks.Add(new Landmark
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Location = reader.GetString(3),
                    YearEstablished = reader.GetInt32(4)
                });
            }

            return landmarks;
        }
    }
}
