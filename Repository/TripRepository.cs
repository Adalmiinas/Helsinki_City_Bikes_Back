﻿using System;
using AutoMapper;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;
using Microsoft.Data.SqlClient;

namespace HelsinkiBikes.Repository
{
    public class TripRepository : ITripRepository
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["helsinkiBikes"].ConnectionString;

        /// <summary>
        /// Get one page of trips, which is ten trips at a time
        /// </summary>
        /// <param name="page"> page number </param>
        /// <returns> IEnumerable<TripReadDTO>  </returns>
        public IEnumerable<TripReadDTO> GetOnePageOfTrips(int page)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM Trips ORDER BY id OFFSET @start ROWS FETCH NEXT 10 ROWS ONLY;";
                using var command = new SqlCommand(sql, conn);
                int startingpoint = (page - 1) * 10;
                command.Parameters.AddWithValue("@start", startingpoint);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new TripReadDTO(
                        reader.GetInt32(0),
                        reader.GetDateTime(1),
                        reader.GetDateTime(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetInt32(5),
                        reader.GetString(6),
                        reader.GetInt32(7),
                        reader.GetInt32(8)
                        );
                }
            }
        }

        /// <summary>
        /// Get all trips 
        /// </summary>
        /// <returns> IEnumerable<TripReadDTO> </returns>
        public IEnumerable<TripReadDTO> GetAllTrips()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM Trips;";
                using var command = new SqlCommand(sql, conn);


                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new TripReadDTO(
                        reader.GetInt32(0),
                        reader.GetDateTime(1),
                        reader.GetDateTime(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetInt32(5),
                        reader.GetString(6),
                        reader.GetInt32(7),
                        reader.GetInt32(8)
                        );
                }
            }
        }

        /// <summary>
        /// Get how many trips there are in the database
        /// </summary>
        /// <returns> IEnumerable<TripCountDTO> </returns>
        public IEnumerable<TripCountDTO> GetCountOfTrips()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT count(*) FROM Trips;";
                using var command = new SqlCommand(sql, conn);

                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new TripCountDTO(
                        reader.GetInt32(0)
                        );
                }
            }
        }
    }
}

