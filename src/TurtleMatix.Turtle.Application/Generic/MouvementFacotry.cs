using System;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Generic
{
    public class MouvementFacotry : IMouvementFactory
    {
        private readonly IEngineFactory _engineFactory;

        public MouvementFacotry(IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public IMouvement GetMouvement(TurtleOperator turtleOperator)
        {
            switch (turtleOperator)
            {
                case TurtleOperator.Advance:
                    return new AdvanceMouvement(_engineFactory);

                case TurtleOperator.Wait:
                    return new WaitMouvement();

                default:
                    throw new ArgumentOutOfRangeException(nameof(turtleOperator), turtleOperator, null);
            }
        }
    }
}