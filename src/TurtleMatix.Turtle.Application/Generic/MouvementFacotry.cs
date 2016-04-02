using System;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Generic
{
    public class MouvementFacotry : _IMouvementFactory
    {
        private readonly _IEngineFactory _engineFactory;

        public MouvementFacotry(_IEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public _IMouvement GetMouvement(TurtleOperator turtleOperator)
        {
            switch (turtleOperator)
            {
                case TurtleOperator.Advance:
                    return new AdvanceMouvement(_engineFactory);

                case TurtleOperator.GoBackward:
                    return new GoBackwardMouvement(_engineFactory);

                case TurtleOperator.Wait:
                    return new WaitMouvement();

                default:
                    throw new ArgumentOutOfRangeException(nameof(turtleOperator), turtleOperator, null);
            }
        }
    }
}