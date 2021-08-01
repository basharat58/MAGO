using System;

namespace MAGO.Core.Entities
{
    public class ParkingSlotCriteria
	{
		public int NumberOfJumbos { get; set; }
		public int NumberOfJets { get; set; }
		public int NumberOfProps { get; set; }
		public DateTime StartDate { get; set; }
		public int HourOfArrival { get; set; }
		public int TotalNumberOfHoursRequired { get; set; }
	}
}
