namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractRotateMouvement : AbstractMouvement
    {
        protected override sealed int CalculateExecutionTime(int commandValue)
        {
            if (commandValue < 1 || commandValue > 8)
                return 0;

            return commandValue*200;
        }
    }
}