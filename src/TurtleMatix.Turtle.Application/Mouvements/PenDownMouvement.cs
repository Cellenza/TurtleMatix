using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class PenDownMovement : AbstractMovement
    {
        private const int TenCentimeterMouvementDuration = 5000;
        private readonly IEngineFactory _engineFactory;

        public PenDownMovement(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public override void Execute(int value)
        {

        }

        protected override int CalculateExecutionTime(int commandValue)
        {
            return (TenCentimeterMouvementDuration / 10) * commandValue;
        }
    }
}