using System;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.Repository
{
    public interface IStationRepository
    {
        IEnumerable<StationReadDTO> GetAllStations();
        IEnumerable<StationReadDTO> GetStationById(int id);
        IEnumerable<StationCountDTO> GetDeparturesFromStation(int id);
        IEnumerable<StationCountDTO> GetReturnsForStation(int id);
        IEnumerable<StationTopDTO> GetTop5DepartureStationsForStation(int id);
        IEnumerable<StationTopDTO> GetTop5ReturnStationsForStation(int id);
    }
}


