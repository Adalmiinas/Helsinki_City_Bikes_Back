using System;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.Repository
{
    public interface IStationRepository
    {
        IEnumerable<StationReadDTO> GetAllStations();
        IEnumerable<StationReadDTO> GetStationById(int id);
    }
}


