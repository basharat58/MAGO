using MAGO.Core.Helpers;
using MAGO.Core.Repositories;
using MAGO.Core.Requests;
using MAGO.Core.Responses;
using MAGO.Core.Strategies;
using System.Linq;

namespace MAGO.Core.Services
{
    public class PlaneService : IPlaneService
	{
		private readonly IPlaneTypeStrategy[] _planeTypeStrategy;
		private readonly IPlaneRepository _planeRepository;

		public PlaneService(IPlaneTypeStrategy[] planeTypeStrategy, IPlaneRepository planeRepository)
		{
			_planeTypeStrategy = planeTypeStrategy;
			_planeRepository = planeRepository;
		}

		public ParkingResponse BookParkingSlot(ParkingRequest parkingRequest)
		{
			var planeTypeStrategy = _planeTypeStrategy.FirstOrDefault(pts => pts.CanHandle(parkingRequest.Plane.PlaneType));
			if (planeTypeStrategy == null)
			{
				return new ParkingResponse { Success = false, Message = $"The plane type {parkingRequest.Plane.PlaneType} is invalid" };
			}

			var planeParkingSlotDetails = _planeRepository.GetPlaneParkingSlotDetails();
			var bookedParkingSlots = _planeRepository.GetBookedParkingSlots(ParkingSlotHelpers.GetParkingSlotCriteria());

			var result = planeTypeStrategy.Handle(parkingRequest, planeParkingSlotDetails, bookedParkingSlots);
			if (result == null)
            {
				return new ParkingResponse { Success = false, Message = $"There is no available parking for the plane {parkingRequest.Plane.FlightName}." };
            }
			else
            {
				_planeRepository.BookParkingSlotForPlane(result);
				return new ParkingResponse { Success = true, Message = $"The plane {parkingRequest.Plane.FlightName} has been booked at slot {result.SlotNumber}." };			
			}
		}		
	}
}
