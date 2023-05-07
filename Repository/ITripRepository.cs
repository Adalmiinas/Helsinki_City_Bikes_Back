using System;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.Repository
{
	public interface ITripRepository
	{
        Task<IEnumerable<Trip>> GetAllTrips();
    }
}

