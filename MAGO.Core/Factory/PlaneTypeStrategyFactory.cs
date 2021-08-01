using MAGO.Core.Strategies;

namespace MAGO.Core.Factory
{
    public class PlaneTypeStrategyFactory : IPlaneTypeStrategyFactory
    {
        private readonly JetStrategy _jetStrategy;
        private readonly JumboStrategy _jumboStrategy;
        private readonly PropStrategy _propStrategy;

        public PlaneTypeStrategyFactory(JetStrategy jetStrategy, JumboStrategy jumboStrategy, PropStrategy propStrategy)
        {
            _jetStrategy = jetStrategy;
            _jumboStrategy = jumboStrategy;
            _propStrategy = propStrategy;
        }

        public IPlaneTypeStrategy[] Create() => new IPlaneTypeStrategy[] { _jetStrategy, _jumboStrategy, _propStrategy };
    }
}
