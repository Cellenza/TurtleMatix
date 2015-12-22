using TurtleMatix.Core;

namespace TurtleMatix.Turtle.Application.Generic
{
    public interface _IMouvementFactory
    {
        _IMouvement GetMouvement(TurtleOperator turtleOperator);
    }
}