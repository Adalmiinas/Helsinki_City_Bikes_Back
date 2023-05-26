using System;
using Microsoft.AspNetCore.Mvc;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;
using AutoMapper;

namespace HelsinkiBikes.Controllers
{
    /// <summary>
    /// Controller for the trips
    /// </summary>
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripController(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get one page of trips, which is ten trips at a time
        /// </summary>
        /// <param name="page"> page number</param>
        /// <returns><List<TripReadDTO></returns>
        [HttpGet("Trip/onePage")]
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

        /// <summary>
        /// Get all trips 
        /// </summary>
        /// <returns> ActionResult<List<TripReadDTO>></returns>
        [HttpGet("Trip")]
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

        /// <summary>
        /// Get how many trips there are in the database
        /// </summary>
        /// <returns> ActionResult<List<TripCountDTO>> </returns>
        [HttpGet("Trip/Count")]
        [ProducesResponseType(typeof(List<TripCountDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<TripCountDTO>> GetCountOfTrips()
        {
            try
            {
                return Ok(_mapper.Map<List<TripCountDTO>>(_tripRepository.GetCountOfTrips()));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}

