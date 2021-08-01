using MAGO.Core.Entities;

namespace MAGO.Core.Factory
{
    public class PlaneFactory
    {
		public static IPlane GetPlane(PlaneType planeType)
		{
			IPlane plane = planeType switch
			{
				PlaneType.Jet => new JetPlane(),
				PlaneType.Jumbo => new JumboPlane(),
				_ => new PropPlane()
			};
			return plane;
		}
	}
}
