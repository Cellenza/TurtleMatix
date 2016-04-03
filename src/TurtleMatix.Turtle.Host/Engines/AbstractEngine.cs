using Windows.Devices.Gpio;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Engines
{
    public abstract class AbstractEngine : IEngine
    {
        private readonly GpioPin _pin1;
        private readonly GpioPin _pin2;

        protected abstract int Port1 { get; }
        protected abstract int Port2 { get; }

        protected AbstractEngine()
        {
            var controller = GpioController.GetDefault();

            _pin1 = controller.OpenPin(Port1);
            _pin1.SetDriveMode(GpioPinDriveMode.Output);
            _pin1.Write(GpioPinValue.Low);

            _pin2 = controller.OpenPin(Port2);
            _pin2.SetDriveMode(GpioPinDriveMode.Output);
            _pin2.Write(GpioPinValue.Low);
        }

        public void RightToLeft()
        {
            _pin1.Write(GpioPinValue.High);
            _pin2.Write(GpioPinValue.Low);
        }

        public void LeftToRight()
        {
            _pin1.Write(GpioPinValue.Low);
            _pin2.Write(GpioPinValue.High);
        }

        public void Stop()
        {
            _pin1.Write(GpioPinValue.Low);
            _pin2.Write(GpioPinValue.Low);
        }
    }
}