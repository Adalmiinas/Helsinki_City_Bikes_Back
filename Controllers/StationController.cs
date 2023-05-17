using System;
using AutoMapper;
using HelsinkiBikes.Model;
using HelsinkiBikes.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace HelsinkiBikes.Controllers
{
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationController(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllStations")]
        [ProducesResponseType(typeof(List<StationReadDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationReadDTO>> GetAllStations()
        {
            try
            {
                return Ok(_mapper.Map<List<StationReadDTO>>(_stationRepository.GetAllStations()));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}

