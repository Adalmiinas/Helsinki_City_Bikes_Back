﻿using System;
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

        [HttpGet("Station")]
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

        [HttpGet("Station/id")]
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


        [HttpGet("Station/Departures")]
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


        [HttpGet("Station/Returns")]
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

        [HttpGet("Station/Top5ReturnStations")]
        [ProducesResponseType(typeof(List<StationTopDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationTopDTO>> GetTop5ReturnStationsForStation(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationTopDTO>>(_stationRepository.GetTop5ReturnStationsForStation(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }


        [HttpGet("Station/Top5DepartureStations")]
        [ProducesResponseType(typeof(List<StationTopDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationTopDTO>> GetTop5DepartureStationsForStation(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationTopDTO>>(_stationRepository.GetTop5DepartureStationsForStation(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpGet("Station/GetAvgDistanceStartingFrom")]
        [ProducesResponseType(typeof(List<StationCountDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationCountDTO>> GetAvgDistanceStartingFrom(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationCountDTO>>(_stationRepository.GetAvgDistanceStartingFrom(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }


        [HttpGet("Station/GetAvgDistanceEndingTo")]
        [ProducesResponseType(typeof(List<StationCountDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public ActionResult<List<StationCountDTO>> GetAvgDistanceEndingTo(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<StationCountDTO>>(_stationRepository.GetAvgDistanceEndingTo(id)));
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}

