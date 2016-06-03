using System;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Generic
{
    public class MovementFacotry : IMovementFactory
    {
        private readonly IEngineFactory _engineFactory;

        public MovementFacotry(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public IMovement GetMovement(TurtleOperator turtleOperator)
        {
            switch (turtleOperator)
            {
                case TurtleOperator.Advance:
                    return new AdvanceMovement(_engineFactory);
                
                case TurtleOperator.TurnLeft:
                    return new TurnLeftMovement(_engineFactory);

                case TurtleOperator.TurnRight:
                    return new TurnRightMovement(_engineFactory);

                case TurtleOperator.PenDown:
                    return new PenDownMovement(_engineFactory);

                case TurtleOperator.PenUp:
                    return new PenUpMovement(_engineFactory);

                case TurtleOperator.Wait:
                    return new WaitMovement();

                default:
                    throw new ArgumentOutOfRangeException(nameof(turtleOperator), turtleOperator, null);
            }
        }
    }
}