using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class WaitMovement : AbstractMovement
    {
        public override void Execute(int value)
        {
            Task.Delay(CalculateExecutionTime(value)).Wait();
        }

        protected override int CalculateExecutionTime(int commandValue)
        {
            return commandValue*1000;
        }
    }
}