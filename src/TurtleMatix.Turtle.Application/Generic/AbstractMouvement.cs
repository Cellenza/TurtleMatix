namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractMovement : IMovement
    {
        public abstract void Execute(int value);
        
        protected abstract int CalculateExecutionTime(int commandValue);

    }
}