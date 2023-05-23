using System;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.Repository
{
    public interface ITripRepository
    {
        IEnumerable<TripReadDTO> GetOnePageOfTrips(int page);
        IEnumerable<TripReadDTO> GetAllTrips();
        IEnumerable<TripCountDTO> GetCountOfTrips();
    }
}

