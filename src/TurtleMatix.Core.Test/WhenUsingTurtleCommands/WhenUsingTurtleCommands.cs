namespace TurtleMatix.Core.Test.WhenUsingTurtleCommands
{
    public class WhenUsingTurtleCommands : SpecificationBase
    {
        protected TurtleCommand Command => new TurtleCommand(TurtleOperator.Advance, 6);
    }
}