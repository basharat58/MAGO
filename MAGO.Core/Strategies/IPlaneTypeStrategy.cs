using MAGO.Core.Entities;
using MAGO.Core.Requests;
using System.Collections.Generic;

namespace MAGO.Core.Strategies
{
    public interface IPlaneTypeStrategy
	{
		int MaximumSlots { get; }
		bool CanHandle(PlaneType planeType);
		BookSlot Handle(ParkingRequest parkingRequest, List<ParkingSlotDetails> parkingSlotDetails, List<BookedPlaneParkingSlot> bookedPlaneParkingSlot);
	}
}
