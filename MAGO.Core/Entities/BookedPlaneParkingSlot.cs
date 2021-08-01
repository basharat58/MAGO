using System;

namespace MAGO.Core.Entities
{
    public class BookedPlaneParkingSlot
	{
		public Plane Plane { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int SlotNumber { get; set; }
	}
}
