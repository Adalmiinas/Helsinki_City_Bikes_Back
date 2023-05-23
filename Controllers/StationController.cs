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

        public StationController(IStationRepository stationrepository, IMapper mapper)
        {
            _stationRepository = stationrepository;
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

        [HttpGet("GetStationById")]
        [ProducesResponseType(typeof(List<StationReadDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationReadDTO>> GetStationsById(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationReadDTO>>(_stationRepository.GetStationById(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }


        [HttpGet("GetDeparturesFromStation")]
        [ProducesResponseType(typeof(List<StationCountDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationCountDTO>> GetDeparturesFromStation(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationCountDTO>>(_stationRepository.GetDeparturesFromStation(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }


        [HttpGet("GetReturnsForStation")]
        [ProducesResponseType(typeof(List<StationCountDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationCountDTO>> GetReturnsForStation(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationCountDTO>>(_stationRepository.GetReturnsForStation(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}

