using System;
using HelsinkiBikes.Model;
using Microsoft.Data.SqlClient;
using System;
using AutoMapper;
using HelsinkiBikes.Repository;

namespace HelsinkiBikes.Repository
{
    public class StationRepository : IStationRepository
    {
        public IEnumerable<StationReadDTO> GetAllStations()
        {
            using (SqlConnection conn = new SqlConnection(@"Data source= localhost; User id=SA; Password=Password123;Initial Catalog = HelsinkiBikes;"))
            {
                conn.Open();
                var sql = "SELECT * FROM Stations;";
                using var command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationReadDTO(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9),
                        reader.GetInt32(10),
                        reader.GetString(11),
                        reader.GetString(12)
                        );
                }
            }
        }
    }
}

