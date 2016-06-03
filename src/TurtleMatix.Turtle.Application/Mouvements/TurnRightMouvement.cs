using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class TurnRightMouvement : AbstractRotateMouvement
    {
        private readonly IEngineFactory _engineFactory;

        public TurnRightMouvement(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var leftEngine = _engineFactory.GetLeftEngine();
            var rightEngine = _engineFactory.GetRightEngine();
            leftEngine.RightToLeft();
            rightEngine.LeftToRight();
            Task.Delay(CalculateExecutionTime(value)).Wait();
            leftEngine.Stop();
            rightEngine.Stop();
        }
    }
}