using MAGO.Core.Entities;
using System;

namespace MAGO.Core.Helpers
{
    public static class ParkingSlotHelpers
    {
		public static ParkingSlotCriteria GetParkingSlotCriteria()
		{
			return new ParkingSlotCriteria
			{
				NumberOfJumbos = 25,
				NumberOfJets = 49,
				NumberOfProps = 25,
				StartDate = new DateTime(2021, 8, 3),
				HourOfArrival = 14,
				TotalNumberOfHoursRequired = 3
			};
		}

		public static DateTime GetParkingSlotTime(DateTime startDate, int hourOfArrival)
        {
			var rand = new Random();

			return hourOfArrival != 0 ?
				new DateTime(startDate.Year, startDate.Month, startDate.Day, hourOfArrival, 0, 0) :
				new DateTime(startDate.Year, startDate.Month, startDate.Day, rand.Next(1, 23), 0, 0);
		}
	}
}
