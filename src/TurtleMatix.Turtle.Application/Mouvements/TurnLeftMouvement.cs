using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class TurnLeftMouvement : AbstractRotateMouvement
    {
        private readonly IEngineFactory _engineFactory;

        public TurnLeftMouvement(IEngineFactory engineFactory)
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