using System;
using System.Globalization;
using BureauOfMeteorology.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BureauOfMeteorology.Facade
{
    public class ObservationFacade 
    {
        public StationObservation GetObservation(string stationCode)
        {
            var client = new RestClient("http://www.bom.gov.au");
            var request = new RestRequest("fwo/IDN60801/IDN60801.{stationCode}.json");
            request.AddUrlSegment("stationCode", stationCode);
            var response = client.Execute(request);

            if(response.IsSuccessful == false) throw new InvalidOperationException(response.ErrorMessage);


            var jobj = JObject.Parse(response.Content);
            var data = (JArray)jobj["observations"]["data"];

            var result = new StationObservation();
            foreach (var token in data)
            {
                var observation = new Observation();
                // 2018 09 05 21 30 00
                observation.LocalDateTime = DateTime.ParseExact(token["local_date_time_full"].ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                observation.ApparentTemperature = decimal.Parse(token["apparent_t"].ToString());
                observation.WindGustKmh = int.Parse(token["gust_kmh"].ToString());
                observation.WindGustKnots = int.Parse(token["gust_kt"].ToString());
                observation.WindSpeedKmh = int.Parse(token["wind_spd_kmh"].ToString());
                observation.WindSpeedKnots = int.Parse(token["wind_spd_kt"].ToString());
                observation.WindDirection= token["wind_dir"].ToString();
                observation.Temperature = decimal.Parse(token["air_temp"].ToString());
                observation.DewPoint = decimal.Parse(token["dewpt"].ToString());
                observation.AirPressure = decimal.Parse(token["press"].ToString());
                observation.RelativeHumidity = int.Parse(token["rel_hum"].ToString());


                result.Observations.Add(observation);
            }

            return result;
        }
    }
}
