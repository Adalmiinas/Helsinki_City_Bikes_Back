using System;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using HelsinkiBikes.Model;
using Microsoft.Data.SqlClient;

namespace HelsinkiBikes.Import
{
    public class ImportData
    {
        public string ConnectionString { get; set; } = string.Empty;

        public CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.Replace(" ", "").Replace("(m)", "").Replace("(sec.)", "")
        };


        public void seeding(string data)
        {

            using (SqlConnection conn = new SqlConnection(@"Data source= localhost; User id=SA; Password=Password123;Initial Catalog = HelsinkiBikes;")) {
                conn.Open();
            using (StreamReader reader = new StreamReader(data))
            {
                using (CsvReader csv = new CsvReader(reader, config))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        IEnumerable<TripInfo> trips = csv.GetRecords<TripInfo>().ToList();
                        foreach (TripInfo trip in trips)
                    {
                        
                        var sql = "INSERT INTO Trips (DepartureTime, ReturnTime, DepartureStationId, DepartureStationName, ReturnStationId, ReturnStationName,Distance,Duration) VALUES(@Departure, @Return, @DepartureStationId, @DepartureStationName, @ReturnStationId, @ReturnStationName, @Distance, @Duration)";
                        using var command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@Departure", trip.Departure);
                        command.Parameters.AddWithValue("@Return", trip.Return);
                        command.Parameters.AddWithValue("@DepartureStationId", trip.Departurestationid);
                        command.Parameters.AddWithValue("@DepartureStationName", trip.Departurestationname);
                        command.Parameters.AddWithValue("@ReturnStationId", trip.Returnstationid);
                        command.Parameters.AddWithValue("@ReturnStationName", trip.Returnstationname);
                        command.Parameters.AddWithValue("@Distance", (int) trip.Covereddistance);
                        command.Parameters.AddWithValue("@Duration", trip.Duration);
                        command.ExecuteNonQuery();
                    }

                }
            }
        }

        }

    }
}
