using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;

namespace TurtleMatix.Core.Test.WhenUsingTurtleCommands
{
    [TestClass]
    public class AndTryToCheckMatchBetweenConversionMethods : WhenUsingTurtleCommands
    {
        private TurtleCommand _GeneratedCommand;

        protected override void Because_of()
        {
            base.Because_of();
            _GeneratedCommand = TurtleCommand.FromString(Command.ToString());

        }

        [TestMethod]
        public void ThenTheTwoCommandsShouldMatchs()
        {
            _GeneratedCommand.ToString().ShouldEqual(Command.ToString());
        }
        

    }
}