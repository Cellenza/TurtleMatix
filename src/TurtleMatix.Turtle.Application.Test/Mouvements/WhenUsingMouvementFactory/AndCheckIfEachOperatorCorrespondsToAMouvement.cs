using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingMouvementFactory
{

    [TestClass]
    public class AndCheckIfEachOperatorCorrespondsToAMouvement : WhenUsingMouvementFactory
    {
        private IMouvement _mouvement;

        private ArgumentOutOfRangeException _catchedException;

        protected override void Because_of()
        {
            base.Because_of();

            try
            {
                foreach (TurtleOperator type in Enum.GetValues(typeof(TurtleOperator)))
                {
                    _mouvement = Factory.GetMouvement(type);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _catchedException = e;
            }

        }

        [TestMethod]
        public void ThenNoExceptionsShouldBeHandled()
        {
            _catchedException.ShouldBeNull();
        }
    }
}