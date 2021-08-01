using MAGO.Core.Requests;
using MAGO.Core.Responses;

namespace MAGO.Core.Services
{
    public interface IPlaneService
    {
        ParkingResponse BookParkingSlot(ParkingRequest parkingRequest);
    }
}
