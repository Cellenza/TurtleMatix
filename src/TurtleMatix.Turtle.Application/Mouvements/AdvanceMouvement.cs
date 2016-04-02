using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class AdvanceMouvement : AbstractMouvement
    {
        private readonly IEngineFactory _engineFactory;

        public AdvanceMouvement(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var leftEngine = _engineFactory.GetLeftEngine();
            var rightEngine = _engineFactory.GetRightEngine();
            leftEngine.TurnOn(EngineDirection.RightToLeft);
            rightEngine.TurnOn(EngineDirection.RightToLeft);
            Task.Delay(CalculateRuntime(value)).Wait();
            leftEngine.TurnOff();
            rightEngine.TurnOff();
        }
    }
}