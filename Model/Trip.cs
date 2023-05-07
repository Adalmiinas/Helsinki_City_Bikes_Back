using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelsinkiBikes.Model
{
    public class Trip
    {

        public int id { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public int? DepartureStationId { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public String? DepartureStationName { get; set; }

        public int? ReturnStationId { get; set; }

        public string? ReturnStationName { get; set; }

        public int? Distance { get; set; }

        public int? Duration { get; set; }
    }
}