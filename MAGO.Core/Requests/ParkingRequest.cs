using MAGO.Core.Entities;
using System;

namespace MAGO.Core.Requests
{
    public class ParkingRequest
	{
		public Plane Plane { get; set; }
		public DateTime StartDate { get; set; }
		public int HourOfArrival { get; set; }
		public int TotalNumberOfHoursRequired { get; set; }
	}
}
