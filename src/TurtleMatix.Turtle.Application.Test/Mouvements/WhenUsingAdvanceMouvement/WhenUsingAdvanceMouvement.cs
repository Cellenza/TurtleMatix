using Moq;
using TurtleMatix.Turtle.Application.Generic;
using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingAdvanceMouvement
{
    public class WhenUsingAdvanceMouvement : SpecificationBase
    {
        protected AdvanceMouvement Mouvement { get; set; }

        protected Mock<IEngineFactory> EngineFactory { get; private set; }

        protected Mock<IEngine> Engine { get; private set; }

        protected int Distance => 1;
        protected int ExpectedTime => AbstractMouvement.TenCentimeterMouvementDuration / 10;
        
        protected override void Establish_context()
        {
            base.Establish_context();
            EngineFactory = new Mock<IEngineFactory>();
            Engine = new Mock<IEngine>();
            EngineFactory.Setup(x => x.GetBackEngine()).Returns(Engine.Object);
            Mouvement = new AdvanceMouvement(EngineFactory.Object);
        }
    }
}