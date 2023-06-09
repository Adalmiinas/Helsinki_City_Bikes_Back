﻿using System;
using HelsinkiBikes.Model;
using Microsoft.Data.SqlClient;
using System;
using AutoMapper;
using HelsinkiBikes.Repository;
using System.Configuration;

namespace HelsinkiBikes.Repository
{
    public class StationRepository : IStationRepository
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["helsinkiBikes"].ConnectionString;

        /// <summary>
        /// Get all stations
        /// </summary>
        /// <returns> IEnumerable<StationReadDTO> </returns>
        public IEnumerable<StationReadDTO> GetAllStations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
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

        /// <summary>
        /// Get station by its id
        /// </summary>
        /// <param name="id">station id</param>
        /// <returns> IEnumerable<StationReadDTO> </returns>
        public IEnumerable<StationReadDTO> GetStationById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM Stations WHERE stationId = @id;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
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

        /// <summary>
        /// Get the amount of departures from a station
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationCountDTO> </returns>
        public IEnumerable<StationCountDTO> GetDeparturesFromStation(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT count(*) FROM Trips WHERE DepartureStationId = @id;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationCountDTO(
                        reader.GetInt32(0)
                        );
                }
            }
        }

        /// <summary>
        /// Get the amount of returns for a station
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationCountDTO> </returns>
        public IEnumerable<StationCountDTO> GetReturnsForStation(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT count(*) FROM Trips WHERE ReturnStationId = @id;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationCountDTO(
                        reader.GetInt32(0)
                        );
                }
            }
        }
        /// <summary>
        /// Get the top five stations where people starting this station returns to.
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationTopDTO> </returns>
        public IEnumerable<StationTopDTO> GetTop5ReturnStationsForStation(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT TOP (5) ReturnStationName, COUNT(*) Total FROM Trips WHERE DepartureStationId = @id  GROUP BY ReturnStationName ORDER BY Total DESC;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationTopDTO(
                        reader.GetString(0),
                        reader.GetInt32(1)
                        );
                }
            }
        }
        /// <summary>
        /// Get the top five stations where people ending at this station departed from.
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationTopDTO> </returns>
        public IEnumerable<StationTopDTO> GetTop5DepartureStationsForStation(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT TOP (5) DepartureStationName, COUNT(*) Total FROM Trips WHERE ReturnStationId = @id  GROUP BY DepartureStationName ORDER BY Total DESC;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationTopDTO(
                        reader.GetString(0),
                        reader.GetInt32(1)
                        );
                }
            }
        }

        /// <summary>
        /// Get the average distance when starting from this station
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationCountDTO> </returns>
        public IEnumerable<StationCountDTO> GetAvgDistanceStartingFrom(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT  AVG(Distance) FROM Trips WHERE ReturnStationId = @id;";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationCountDTO(
                        reader.GetInt32(0)
                        );
                }
            }
        }

        /// <summary>
        /// Get the average distance when ending at this station
        /// </summary>
        /// <param name="id"> station id </param>
        /// <returns> IEnumerable<StationCountDTO> </returns>
        public IEnumerable<StationCountDTO> GetAvgDistanceEndingTo(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT  AVG(Distance) FROM Trips WHERE DepartureStationId = @id; ";
                using var command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new StationCountDTO(
                      reader.GetInt32(0)
                        );
                }
            }
        }
    }
}

