using System;
using Microsoft.AspNetCore.Mvc;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;
using AutoMapper;

namespace HelsinkiBikes.Controllers
{
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripController(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        [HttpGet("GetOnePage")]
        [ProducesResponseType(typeof(List<TripReadDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<TripReadDTO>> GetOnePageOfTrips(int page)
        {
            try
            {
                return Ok(_mapper.Map<List<TripReadDTO>>(_tripRepository.GetOnePageOfTrips(page)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpGet("GetAllTrips")]
        [ProducesResponseType(typeof(List<TripReadDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<TripReadDTO>> GetAllTrips()
        {
            try
            {
                return Ok(_mapper.Map<List<TripReadDTO>>(_tripRepository.GetAllTrips()));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}

