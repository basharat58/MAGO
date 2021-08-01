using MAGO.Core.Strategies;

namespace MAGO.Core.Factory
{
    public interface IPlaneTypeStrategyFactory
    {
        IPlaneTypeStrategy[] Create();
    }
}
