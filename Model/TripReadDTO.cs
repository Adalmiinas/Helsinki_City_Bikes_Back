using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelsinkiBikes.Model
{
    public readonly record struct TripReadDTO(int id, DateTime Departure, DateTime Return,
        int DepartureStationId, string DepartureStationName, int ReturnStationId,
        string ReturnStationName, float Distance, int Duration);

}

