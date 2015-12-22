namespace TurtleMatix.Turtle.Application.Generic
{
    public interface _IEngineFactory
    {
        _IEngine GetFrontEngine();

        _IEngine GetBackEngine();
    }
}