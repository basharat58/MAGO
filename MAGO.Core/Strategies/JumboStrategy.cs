using MAGO.Core.Configuration;
using MAGO.Core.Entities;
using MAGO.Core.Requests;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAGO.Core.Strategies
{
    public class JumboStrategy : IPlaneTypeStrategy
	{
		private readonly IOptions<PlaneConfig> _planeConfig;

		public JumboStrategy(IOptions<PlaneConfig> planeConfig)
		{
			_planeConfig = planeConfig;
		}

		public int MinimumSlots { get => _planeConfig.Value.JumboMinimumSlot; }
		public int MaximumSlots { get => _planeConfig.Value.JumboMaximumSlot; }
		public bool CanHandle(PlaneType planeType) => planeType == PlaneType.Jumbo;

		public BookSlot Handle(ParkingRequest parkingRequest, List<ParkingSlotDetails> parkingSlotDetails, List<BookedPlaneParkingSlot> bookedPlaneParkingSlot)
		{
			var startDate = new DateTime(parkingRequest.StartDate.Year, parkingRequest.StartDate.Month, parkingRequest.StartDate.Day,
				parkingRequest.HourOfArrival, 0, 0);
			var endDate = startDate.AddHours(parkingRequest.TotalNumberOfHoursRequired);
			var emptySlot = bookedPlaneParkingSlot
				.Where(ps => ps.Plane.PlaneType == parkingRequest.Plane.PlaneType 
					&& startDate >= ps.StartDate && startDate <= ps.EndDate)
				.OrderByDescending(ps => ps.SlotNumber)
				.FirstOrDefault();
			if (emptySlot != null)
            {
				if (emptySlot.SlotNumber < MaximumSlots)
                {
					return new BookSlot
					{
						SlotNumber = emptySlot.SlotNumber + 1,
						Plane = parkingRequest.Plane,
						StartDate = startDate,
						EndDate = endDate
					};
				}
				return null;
			}
			return new BookSlot
			{
				SlotNumber = MinimumSlots,
				Plane = parkingRequest.Plane,
				StartDate = startDate,
				EndDate = endDate
			};
		}
	}
}
