namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractMouvement : IMouvement
    {
        public abstract void Execute(int value);
        
        protected abstract int CalculateExecutionTime(int commandValue);

    }
}