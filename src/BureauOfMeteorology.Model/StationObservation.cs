using System.Collections.Generic;

namespace BureauOfMeteorology.Model
{
    public class StationObservation
    {
        public string StationName { get; set; }

        public string StationId { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public List<Observation> Observations { get; set; } = new List<Observation>();
    }
}
