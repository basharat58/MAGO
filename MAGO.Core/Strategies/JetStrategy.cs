using MAGO.Core.Configuration;
using MAGO.Core.Entities;
using MAGO.Core.Requests;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAGO.Core.Strategies
{
    public class JetStrategy : BaseStrategy, IPlaneTypeStrategy
	{
		private readonly IOptions<PlaneConfig> _planeConfig;		
		public JetStrategy(IOptions<PlaneConfig> planeConfig)
        {
			_planeConfig = planeConfig;
        }

		public int MinimumSlots { get => _planeConfig.Value.JetMinimumSlot; }
		public int MaximumSlots { get => _planeConfig.Value.JetMaximumSlot; }
		public int TotalSlots { get => _planeConfig.Value.TotalSlots; }
		public bool CanHandle(PlaneType planeType) => planeType == PlaneType.Jet;

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
			var normalParkingSlot = NormalPlaneParkingSlot(emptySlot, parkingRequest.Plane, startDate, endDate, MinimumSlots, MaximumSlots);
			if (normalParkingSlot != null)
            {
				return normalParkingSlot;
			}

			// Check to see if there is space in larger slots
			emptySlot = bookedPlaneParkingSlot
				.Where(ps => (int)ps.Plane.PlaneType > (int)parkingRequest.Plane.PlaneType
					&& startDate >= ps.StartDate && startDate <= ps.EndDate)
				.OrderByDescending(ps => ps.SlotNumber)
				.FirstOrDefault();

			return LargerPlaneParkingSlot(emptySlot, parkingRequest.Plane, startDate, endDate, MinimumSlots, TotalSlots);
		}
	}
}
