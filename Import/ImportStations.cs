using System;
using CsvHelper;
using CsvHelper.Configuration;
using HelsinkiBikes.Model;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace HelsinkiBikes.Import
{
    public class ImportStations
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["helsinkiBikes"].ConnectionString;

        public CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
        };


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
                        IEnumerable<StationDTO> stations = csv.GetRecords<StationDTO>().ToList();
                        foreach (StationDTO station in stations)
                        {

                            var sql = "INSERT INTO Stations (StationId, Name, SwedishName, EnglishName, Address, SwedishAddress,City,SwedishCityName, Operator, Capacity, xAxel, yAxel) " +
                                "VALUES(@StationId, @Name, @SwedishName, @EnglishName, @Address, @SwedishAddress, @City, @SwedishCityName, @Operator, @capacity, @xAxel, @yAxel)";
                            using var command = new SqlCommand(sql, conn);
                            command.Parameters.AddWithValue("@StationId", station.ID);
                            command.Parameters.AddWithValue("@Name", station.Nimi);
                            command.Parameters.AddWithValue("@SwedishName", station.Namn);
                            command.Parameters.AddWithValue("@EnglishName", station.Name);
                            command.Parameters.AddWithValue("@Address", station.Osoite);
                            command.Parameters.AddWithValue("@SwedishAddress", station.Adress);
                            command.Parameters.AddWithValue("@City", station.Kaupunki);
                            command.Parameters.AddWithValue("@SwedishCityName", station.Stad);
                            command.Parameters.AddWithValue("@Operator", station.Operaattor);
                            command.Parameters.AddWithValue("@capacity", station.Kapasiteet);
                            command.Parameters.AddWithValue("@xAxel", station.x);
                            command.Parameters.AddWithValue("@yAxel", station.y);
                            command.ExecuteNonQuery();
                        }

                    }
                }
            }

        }
    }
}

