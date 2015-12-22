using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingWaitMouvement
{
    [TestClass]
    public class AndTryToExecute : WhenUsingWaitMouvement
    {
        private TimeSpan _duration;

        protected override void Because_of()
        {
            base.Because_of();

            var start = DateTime.Now;
            Mouvement.Execute(WaitTime);
            _duration = DateTime.Now.Subtract(start);
        }
        
        [TestMethod]
        public void ThenTheExecutionTimeShouldBeGreaterOrEqualsThanExpected()
        {
            Convert.ToInt32(_duration.TotalMilliseconds /1000).ShouldBeGreaterThanOrEqualTo(WaitTime);
        }

    }
}