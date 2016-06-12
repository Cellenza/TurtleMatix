using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class TurnRightMovement : AbstractRotateMovement
    {
        private readonly IEngineFactory _engineFactory;

        public TurnRightMovement(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var leftEngine = _engineFactory.GetLeftEngine();
            var rightEngine = _engineFactory.GetRightEngine();
            leftEngine.LeftToRight();
            rightEngine.RightToLeft();
            Task.Delay(CalculateExecutionTime(value)).Wait();
            leftEngine.Stop();
            rightEngine.Stop();
        }
    }
}