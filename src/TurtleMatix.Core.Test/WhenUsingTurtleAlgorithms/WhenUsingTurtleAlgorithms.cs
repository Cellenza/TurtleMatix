using System.Collections.Generic;

namespace TurtleMatix.Core.Test.WhenUsingTurtleAlgorithms
{
    public class WhenUsingTurtleAlgorithms : SpecificationBase
    {
        protected TurtleAlgorithm Algorithm =>new TurtleAlgorithm()
        {
            Commands = new List<TurtleCommand>()
            {
                new TurtleCommand(TurtleOperator.Advance, 5),
                new TurtleCommand(TurtleOperator.GoBackward, 3),
                new TurtleCommand(TurtleOperator.Advance, 9),
                new TurtleCommand(TurtleOperator.GoBackward, 8)
            }
        };
    }
}