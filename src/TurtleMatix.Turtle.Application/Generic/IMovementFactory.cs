using TurtleMatix.Core;

namespace TurtleMatix.Turtle.Application.Generic
{
    public interface IMovementFactory
    {
        IMovement GetMovement(TurtleOperator turtleOperator);
    }
}