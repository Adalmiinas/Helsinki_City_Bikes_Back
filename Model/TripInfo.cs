using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelsinkiBikes.Model
{
	public class TripInfo
	{
        public DateTime Departure { get; set; }

        public DateTime Return { get; set; }

        public int Departurestationid { get; set; }

        public String Departurestationname { get; set; }

        public int Returnstationid { get; set; }

        public string Returnstationname { get; set; }

        public float Covereddistance { get; set; }

        public int Duration { get; set; }
    }
	
}

