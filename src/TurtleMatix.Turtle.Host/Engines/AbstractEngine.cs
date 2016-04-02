using Windows.Devices.Gpio;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Engines
{
    public abstract class AbstractEngine : IEngine
    {
        protected GpioController Controller { get; private set; }

        protected AbstractEngine()
        {
            Controller = GpioController.GetDefault();
        }

        public abstract void TurnOn(EngineDirection direction);

        public abstract void TurnOff();
    }
}