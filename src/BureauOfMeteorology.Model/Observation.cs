using System;
using System.Collections.Generic;
using System.Text;

namespace BureauOfMeteorology.Model
{
    public class Observation
    {
        public string ProductId { get; set; }

        public DateTime LocalDateTime { get; set; }

        public decimal Temperature { get; set; }

        public decimal ApparentTemperature { get; set; }

        public decimal DewPoint { get; set; }

        public decimal AirPressure { get; set; }

        public int RelativeHumidity { get; set; }

        public decimal Rain { get; set; }

        public int WindSpeedKmh { get; set; }

        public int WindSpeedKnots { get; set; }

        public int WindGustKmh { get; set; }

        public int WindGustKnots { get; set; }

        public string WindDirection { get; set; }

    }
}
