using TurtleMatix.Core;

namespace TurtleMatix.Turtle.Application.Generic
{
    public interface IMouvementFactory
    {
        IMouvement GetMouvement(TurtleOperator turtleOperator);
    }
}