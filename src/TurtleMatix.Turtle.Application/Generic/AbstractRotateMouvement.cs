namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractRotateMouvement : AbstractMouvement
    {
        protected override sealed int CalculateExecutionTime(int commandValue)
        {
            switch (commandValue)
            {
                case 1:
                    return 220;
                case 2:
                    return 340;
                case 3:
                    return 460;
                case 4:
                    return 620;
                default:
                    return 0;
            }
        }
    }
}