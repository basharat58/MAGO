using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAGO.Core.Entities
{
    public class Plane
	{
		public string FlightName { get; set; }
		public string Id { get; set; }

		[JsonProperty("planeType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public PlaneType PlaneType { get; set; }
	}
}
