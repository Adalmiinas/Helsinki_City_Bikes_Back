using System;
using AutoMapper;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;

namespace HelsinkiBikes.Repository
{
	public class TripRepository : ITripRepository
	{
  
        private readonly IMapper _mapper;

        public TripRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<IEnumerable<Trip>> GetAllTrips()
        {
            return null;
        }
    }
}

