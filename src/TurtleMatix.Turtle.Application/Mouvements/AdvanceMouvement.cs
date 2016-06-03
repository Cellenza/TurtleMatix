using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class AdvanceMovement : AbstractMovement
    {
        private const int TenCentimeterMouvementDuration = 5000;
        private readonly IEngineFactory _engineFactory;

        public AdvanceMovement(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var leftEngine = _engineFactory.GetLeftEngine();
            var rightEngine = _engineFactory.GetRightEngine();
            leftEngine.RightToLeft();
            rightEngine.RightToLeft();
            Task.Delay(CalculateExecutionTime(value)).Wait();
            leftEngine.Stop();
            rightEngine.Stop();
        }

        protected override int CalculateExecutionTime(int commandValue)
        {
            return (TenCentimeterMouvementDuration/10)*commandValue;
        }
    }
}