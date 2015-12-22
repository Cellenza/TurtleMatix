using Moq;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingMouvementFactory
{
    public class WhenUsingMouvementFactory : SpecificationBase
    {
        protected MouvementFacotry Factory { get; set; }

        protected Mock<_IEngineFactory> EngineFactory { get; private set; }
        
        protected override void Establish_context()
        {
            base.Establish_context();
            EngineFactory = new Mock<_IEngineFactory>();
            Factory = new MouvementFacotry(EngineFactory.Object);
        }
    }
}