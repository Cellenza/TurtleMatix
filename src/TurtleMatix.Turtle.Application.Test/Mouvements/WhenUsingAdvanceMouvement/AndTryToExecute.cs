using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Application.Test.Mouvements.WhenUsingAdvanceMouvement
{
    [TestClass]
    public class AndTryToExecute : WhenUsingAdvanceMouvement
    {
        private TimeSpan _duration;

        protected override void Because_of()
        {
            base.Because_of();

            var start = DateTime.Now;
            Mouvement.Execute(Distance);
            _duration = DateTime.Now.Subtract(start);
        }

        [TestMethod]
        public void ThenTheBackEngineShouldStarts()
        {
            Engine.Verify(x=>x.TurnOn(EngineDirection.LeftToRight),Times.Once);
        }

        [TestMethod]
        public void ThenTheBackEngineShouldStops()
        {
            this.Engine.Verify(x => x.TurnOff(), Times.Once);
        }

        [TestMethod]
        public void ThenTheExecutionTimeShouldBeGreaterOrEqualsThanExpected()
        {
            Convert.ToInt32(_duration.TotalMilliseconds).ShouldBeGreaterThanOrEqualTo(ExpectedTime);
        }

    }
}