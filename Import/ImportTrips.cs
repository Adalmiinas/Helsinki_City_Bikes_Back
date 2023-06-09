﻿using System;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HelsinkiBikes.Model;
using Microsoft.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace HelsinkiBikes.Import
{
    public class ImportTrips
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["helsinkiBikes"].ConnectionString;

        //changing the header into a more simplifyed version.
        public CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.Replace(" ", "").Replace("(m)", "").Replace("(sec.)", ""),

        };

        /// <summary>
        /// Importing the trip data to the database
        /// </summary>
        /// <param name="data"> csv file data</param>
        public void seeding(string data)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(data))
                {
                    using (CsvReader csv = new CsvReader(reader, config))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        IEnumerable<TripDTO> trips = csv.GetRecords<TripDTO>().ToList();
                        var check = new DuplicateCheck();
                        foreach (TripDTO trip in trips)
                        {
                            //Checks if the row already exists in the database
                            if (!check.CheckIfTripRowExist(trip))
                            {
                                //Checks that non of the colums are null
                                if (trip.Departure != null && trip.Return != null && trip.Departurestationid != null &&
                                trip.Departurestationname != null && trip.Returnstationid != null && trip.Returnstationname != null
                                && trip.Covereddistance != null && trip.Duration != null)
                                {
                                    //Checks that the data is correct form
                                    if (trip.Departure is DateTime && trip.Return is DateTime && trip.Departurestationid is int &&
                                        trip.Departurestationname is string && trip.Returnstationid is int && trip.Returnstationname is string
                                        && trip.Covereddistance is float && trip.Duration is int)
                                    {
                                        //checks that the distance and duration are more than 9
                                        if (trip.Covereddistance > 9 && trip.Duration > 9)
                                        {

                                            var sql = "INSERT INTO Trips (DepartureTime, ReturnTime, DepartureStationId, DepartureStationName, ReturnStationId, ReturnStationName,Distance,Duration) VALUES(@Departure, @Return, @DepartureStationId, @DepartureStationName, @ReturnStationId, @ReturnStationName, @Distance, @Duration)";
                                            using var command = new SqlCommand(sql, conn);
                                            command.Parameters.AddWithValue("@Departure", trip.Departure);
                                            command.Parameters.AddWithValue("@Return", trip.Return);
                                            command.Parameters.AddWithValue("@DepartureStationId", trip.Departurestationid);
                                            command.Parameters.AddWithValue("@DepartureStationName", trip.Departurestationname);
                                            command.Parameters.AddWithValue("@ReturnStationId", trip.Returnstationid);
                                            command.Parameters.AddWithValue("@ReturnStationName", trip.Returnstationname);
                                            command.Parameters.AddWithValue("@Distance", (int)trip.Covereddistance);
                                            command.Parameters.AddWithValue("@Duration", trip.Duration);
                                            command.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

        }

    }
}
