using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingWaitMouvement
{
    public class WhenUsingWaitMouvement : SpecificationBase
    {
        protected WaitMouvement Mouvement { get; set; }
        protected int WaitTime => 1;
        
        protected override void Establish_context()
        {
            base.Establish_context();
            Mouvement = new WaitMouvement();
        }
    }
}