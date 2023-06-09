﻿using System;
using System.Text;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;

namespace HelsinkiBikes.Import
{
    public class DuplicateCheck
    {
        /// <summary>
        /// Check if a station data row already exists
        /// </summary>
        /// <param name="line"> a new imported line </param>
        /// <returns> Boolean </returns>
        public Boolean CheckIfStationRowExist(StationDTO line)
        {
            var stationRepo = new StationRepository();
            var stations = stationRepo.GetAllStations();
            HashSet<string> ScannedRecords = new HashSet<string>();

            //Add the current database in to hashset
            foreach (var row in stations)
            {
                // Build a string that contains the combined column values
                ScannedRecords.Add(row.stationId.ToString() + row.Name.ToString() +
                    row.SwedishName.ToString() + row.EnglishName.ToString() + row.Address.ToString() +
                    row.SwedishAddress.ToString() + row.City.ToString() + row.SwedishCityName.ToString() +
                    row.Operator.ToString() + row.capacity.ToString() + row.xAxel.ToString() + row.yAxel.ToString());

            }

            // Build a string that contains the combined column values
            string lineString = line.ID.ToString() + line.Nimi.ToString() +
                    line.Namn.ToString() + line.Name.ToString() + line.Osoite.ToString() +
                    line.Adress.ToString() + line.Kaupunki.ToString() + line.Stad.ToString() +
                    line.Operaattor.ToString() + line.Kapasiteet.ToString() + line.x.ToString() + line.y.ToString();

            //Check if data is duplicate.
            if (!ScannedRecords.Add(lineString))
            {
                // This data is a duplicate.
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if a trip data row already exists
        /// </summary>
        /// <param name="line"> a new imported line </param>
        /// <returns> Boolean </returns>
        public Boolean CheckIfTripRowExist(TripDTO line)
        {
            var tripRepo = new TripRepository();
            var trips = tripRepo.GetAllTrips();
            HashSet<string> ScannedRecords = new HashSet<string>();

            //Add the current database in to hashset
            foreach (var row in trips)
            {
                // Build a string that contains the combined column values
                ScannedRecords.Add(row.Departure.ToString() + row.Return.ToString() +
                    row.DepartureStationId.ToString() + row.DepartureStationName.ToString() + row.ReturnStationId.ToString() +
                    row.DepartureStationName.ToString() + row.Distance.ToString() + row.Duration.ToString());

            }

            // Build a string that contains the combined column values
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

