using MAGO.Core.Entities;
using System.Collections.Generic;

namespace MAGO.Core.Repositories
{
    public interface IPlaneRepository
	{
		List<ParkingSlotDetails> GetPlaneParkingSlotDetails();
		List<BookedPlaneParkingSlot> GetBookedParkingSlots(ParkingSlotCriteria parkingSlotCriteria);
		void BookParkingSlotForPlane(BookSlot bookSlot);
	}
}
