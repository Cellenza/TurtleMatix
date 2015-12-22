using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class AdvanceMouvement : AbstractDirectMouvement
    {
        private readonly _IEngineFactory _engineFactory;

        public AdvanceMouvement(_IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var backEngine = _engineFactory.GetBackEngine();
            backEngine.TurnOn(EngineDirection.LeftToRight);
            Task.Delay(CalculateRuntime(value)).Wait();
            backEngine.TurnOff();
        }
    }
}