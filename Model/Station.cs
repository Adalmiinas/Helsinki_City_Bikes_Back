using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelsinkiBikes.Model
{
    public class Station
    {
        public int id { get; set; }

        public int StationId { get; set; }


        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }


        [Column(TypeName = "nvarchar(40)")]
        public string? SwedishName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? EnglishName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? SwedishAddress { get; set; }


        [Column(TypeName = "nvarchar(40)")]
        public string City { get; set; }


        [Column(TypeName = "nvarchar(40)")]
        public string? SwedishCityName { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? Operator { get; set; }

        public int? Capacity { get; set; }

        public string? xAxel { get; set; }

        public string? yAxel { get; set; }
    }
}