namespace TurtleMatix.Turtle.Application.Generic
{
    public interface IEngineFactory
    {
        IEngine GetLeftEngine();

        IEngine GetRightEngine();

        IEngine GetPenEngine();

    }
}