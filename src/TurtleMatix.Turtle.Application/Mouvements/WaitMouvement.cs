using System.Threading.Tasks;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Mouvements
{
    public class WaitMouvement : AbstractDirectMouvement
    {
        public override void Execute(int value)
        {
            Task.Delay(value*1000).Wait();
        }
    }
}