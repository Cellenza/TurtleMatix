using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class GoBackwardMouvement : AbstractDirectMouvement
    {
        private readonly _IEngineFactory _engineFactory;


        public GoBackwardMouvement(_IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {
            var backEngine = _engineFactory.GetBackEngine();
            backEngine.TurnOn(EngineDirection.RightToLeft);
            Task.Delay(CalculateRuntime(value)).Wait();
            backEngine.TurnOff();
        }

    }
}