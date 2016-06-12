namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractRotateMovement : AbstractMovement
    {
        protected override sealed int CalculateExecutionTime(int commandValue)
        {

            return commandValue;
            switch (commandValue)
            {
                case 1:
                    return 280;
                case 2:
                    return 420;
                case 3:
                    return 480;
                case 4:
                    return 620;
                default:
                    return 0;
            }
        }
    }
}