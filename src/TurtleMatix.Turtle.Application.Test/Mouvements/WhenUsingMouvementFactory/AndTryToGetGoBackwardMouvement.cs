using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Generic;
using TurtleMatix.Turtle.Application.Mouvements;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingMouvementFactory
{
    [TestClass]
    public class AndTryToGetGoBackwardMouvement : WhenUsingMouvementFactory
    {
        private _IMouvement _mouvement;

        protected override void Because_of()
        {
            base.Because_of();
            _mouvement = Factory.GetMouvement(TurtleOperator.GoBackward);
        }

        [TestMethod]
        public void ThenTheFactoryShouldReturnTheGoodInstance()
        {
            _mouvement.ShouldBeInstanceOfType(typeof(GoBackwardMouvement));
        }
    }
}