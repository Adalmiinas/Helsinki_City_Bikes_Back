using System;
namespace HelsinkiBikes.Model
{
	public class Trip
	{
		public DateTime Departure { get; set; }
		public DateTime Return { get; set; }
		public int DepartureStationId { get; set; }
		public String DepartureStationName { get; set; }
		public int ReturnStationId { get; set; }
		public string ReturnStationName { get; set; }
		public int Distance { get; set; }
		public int Duration { get; set; }
    }
}