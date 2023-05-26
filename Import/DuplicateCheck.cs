using System;
using System.Text;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;

namespace HelsinkiBikes.Import
{
    public class DuplicateCheck
    {
        public Boolean CheckIfStationRowExist(StationDTO line)
        {
            var stationRepo = new StationRepository();
            var stations = stationRepo.GetAllStations();
            HashSet<string> ScannedRecords = new HashSet<string>();
            StringBuilder sb = new StringBuilder();

            foreach (var row in stations)
            {
                // Build a string that contains the combined column values
                ScannedRecords.Add(row.stationId.ToString() + row.Name.ToString() +
                    row.SwedishName.ToString() + row.EnglishName.ToString() + row.Address.ToString() +
                    row.SwedishAddress.ToString() + row.City.ToString() + row.SwedishCityName.ToString() +
                    row.Operator.ToString() + row.capacity.ToString() + row.xAxel.ToString() + row.yAxel.ToString());

            }

            string lineString = line.ID.ToString() + line.Nimi.ToString() +
                    line.Namn.ToString() + line.Name.ToString() + line.Osoite.ToString() +
                    line.Adress.ToString() + line.Kaupunki.ToString() + line.Stad.ToString() +
                    line.Operaattor.ToString() + line.Kapasiteet.ToString() + line.x.ToString() + line.y.ToString();

            if (!ScannedRecords.Add(lineString))
            {
                // This record is a duplicate.
                return true;
            }
            return false;
        }
        public Boolean CheckIfTripRowExist(TripDTO line)
        {
            var tripRepo = new TripRepository();
            var trips = tripRepo.GetAllTrips();
            HashSet<string> ScannedRecords = new HashSet<string>();

            foreach (var row in trips)
            {
                // Build a string that contains the combined column values
                ScannedRecords.Add(row.Departure.ToString() + row.Return.ToString() +
                    row.DepartureStationId.ToString() + row.DepartureStationName.ToString() + row.ReturnStationId.ToString() +
                    row.DepartureStationName.ToString() + row.Distance.ToString() + row.Duration.ToString());

            }

            string lineString = line.Departure.ToString() + line.Return.ToString() + line.Departurestationid.ToString() +
                   line.Departurestationname.ToString() + line.Returnstationid.ToString() + line.Returnstationname.ToString() +
                   line.Covereddistance.ToString() + line.Duration.ToString();

            if (!ScannedRecords.Add(lineString))
            {
                // This record is a duplicate.
                return true;
            }
            return false;
        }
    }
}

