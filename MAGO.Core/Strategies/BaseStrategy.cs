using MAGO.Core.Entities;
using System;

namespace MAGO.Core.Strategies
{
    public abstract class BaseStrategy
    {
        public BookSlot NormalPlaneParkingSlot(
			BookedPlaneParkingSlot parkingSlot, 
			Plane plane,
			DateTime startDate,
			DateTime endDate,
			int minimumSlot,
			int maximumSlot)
        {
			if (parkingSlot == null)
			{
				return new BookSlot
				{
					SlotNumber = minimumSlot,
					Plane = plane,
					StartDate = startDate,
					EndDate = endDate
				};
			}
			else if (parkingSlot.SlotNumber < (minimumSlot + maximumSlot) - 1)
			{
				return new BookSlot
				{
					SlotNumber = parkingSlot.SlotNumber + 1,
					Plane = plane,
					StartDate = startDate,
					EndDate = endDate
				};
			}

			return null;
		}

		public BookSlot LargerPlaneParkingSlot(
			BookedPlaneParkingSlot parkingSlot,
			Plane plane,
			DateTime startDate,
			DateTime endDate,
			int minimumSlot,
			int totalSlots)
        {
			if (parkingSlot != null)
			{
				if (parkingSlot.SlotNumber < totalSlots)
				{
					return new BookSlot
					{
						SlotNumber = parkingSlot.SlotNumber + 1,
						Plane = plane,
						StartDate = startDate,
						EndDate = endDate
					};
				}
				return null;
			}
			return new BookSlot
			{
				SlotNumber = minimumSlot,
				Plane = plane,
				StartDate = startDate,
				EndDate = endDate
			};
		}
	}
}
