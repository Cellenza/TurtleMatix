using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;

namespace TurtleMatix.Core.Test.WhenUsingTurtleAlgorithms
{
    [TestClass]
    public class AndTryToCheckMatchBetweenConversionMethods : WhenUsingTurtleAlgorithms
    {
        private TurtleAlgorithm _generatedAlgorithm;

        protected override void Because_of()
        {
            base.Because_of();
            _generatedAlgorithm = TurtleAlgorithm.FromString(Algorithm.ToString());

        }

        [TestMethod]
        public void ThenTheTwoCommandsShouldMatchs()
        {
            _generatedAlgorithm.ShouldEqual(Algorithm);
        }
        

    }
}