using MAGO.Core.Entities;
using MAGO.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAGO.Core.Repositories
{
    public class PlaneRepository : IPlaneRepository
	{
		public List<ParkingSlotDetails> GetPlaneParkingSlotDetails()
		{
			return new List<ParkingSlotDetails>() {
				new ParkingSlotDetails { PlaneType = PlaneType.Jumbo, FirstSlot = 76, LastSlot = 100 },
				new ParkingSlotDetails { PlaneType = PlaneType.Jet, FirstSlot = 26, LastSlot = 75 },
				new ParkingSlotDetails { PlaneType = PlaneType.Prop, FirstSlot = 1, LastSlot = 25 }
			};
		}

		public List<BookedPlaneParkingSlot> GetBookedParkingSlots(ParkingSlotCriteria parkingSlotCriteria)
		{
			var rand = new Random();
			var bookedPlaneParkingSlots = new List<BookedPlaneParkingSlot>();

			// Props
			var slot = GetPlaneParkingSlotDetails().FirstOrDefault(p => p.PlaneType == PlaneType.Prop).FirstSlot;
			for (int props = 0; props < parkingSlotCriteria.NumberOfProps; props++)
			{
				var plane = new Plane
				{
					Id = "E195",
					FlightName = $"E195{rand.Next(100, 600)}",
					PlaneType = PlaneType.Prop
				};
				var startDate = ParkingSlotHelpers.GetParkingSlotTime(parkingSlotCriteria.StartDate, parkingSlotCriteria.HourOfArrival);

				bookedPlaneParkingSlots.Add(
					new BookedPlaneParkingSlot
					{
						Plane = plane,
						StartDate = startDate,
						EndDate = startDate.AddHours(parkingSlotCriteria.TotalNumberOfHoursRequired),
						SlotNumber = slot + props
					}
				);
			}

			// Jets
			slot = GetPlaneParkingSlotDetails().FirstOrDefault(p => p.PlaneType == PlaneType.Jet).FirstSlot;
			for (int jets = 0; jets < parkingSlotCriteria.NumberOfJets; jets++)
			{
				var id = rand.Next(1, 2) == 1 ? "A330" : "B777";

				var plane = new Plane
				{
					Id = id,
					FlightName = $"{id}{rand.Next(100, 600)}",
					PlaneType = PlaneType.Jet
				};
				var startDate = ParkingSlotHelpers.GetParkingSlotTime(parkingSlotCriteria.StartDate, parkingSlotCriteria.HourOfArrival);

				bookedPlaneParkingSlots.Add(
					new BookedPlaneParkingSlot
					{
						Plane = plane,
						StartDate = startDate,
						EndDate = startDate.AddHours(parkingSlotCriteria.TotalNumberOfHoursRequired),
						SlotNumber = slot + jets
					}
				);
			}

			// Jumbos
			slot = GetPlaneParkingSlotDetails().FirstOrDefault(p => p.PlaneType == PlaneType.Jumbo).FirstSlot;
			for (int jumbos = 0; jumbos < parkingSlotCriteria.NumberOfJumbos; jumbos++)
            {
				var id = rand.Next(1, 2) == 1 ? "A380" : "B747";

				var plane = new Plane
				{
					Id = id,
					FlightName = $"{id}{rand.Next(100, 600)}",
					PlaneType = PlaneType.Jumbo
				};
				var startDate = ParkingSlotHelpers.GetParkingSlotTime(parkingSlotCriteria.StartDate, parkingSlotCriteria.HourOfArrival);

				bookedPlaneParkingSlots.Add(
					new BookedPlaneParkingSlot { 
						Plane = plane, 
						StartDate = startDate,
						EndDate = startDate.AddHours(parkingSlotCriteria.TotalNumberOfHoursRequired),
						SlotNumber = slot + jumbos
					}
				);
			}
			
			return bookedPlaneParkingSlots;				
		}
		public void BookParkingSlotForPlane(BookSlot bookSlot)
        {
			var bookedPlanes = GetBookedParkingSlots(ParkingSlotHelpers.GetParkingSlotCriteria());
			bookedPlanes.Add(new BookedPlaneParkingSlot
			{
				Plane = bookSlot.Plane,
				StartDate = bookSlot.StartDate,
				EndDate = bookSlot.EndDate,
				SlotNumber = bookSlot.SlotNumber
			});
		}
	}
}
