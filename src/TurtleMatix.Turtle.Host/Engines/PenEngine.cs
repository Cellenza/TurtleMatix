using Windows.Devices.Gpio;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Engines
{
    public class PenEngine : AbstractEngine
    {
        private readonly GpioPin _ltrPin;
        private readonly GpioPin _rtlPin;
        public PenEngine()
        {
            _ltrPin = Controller.OpenPin(26);
            _ltrPin.SetDriveMode(GpioPinDriveMode.Output);
            _ltrPin.Write(GpioPinValue.Low);

            _rtlPin = Controller.OpenPin(12);
            _rtlPin.SetDriveMode(GpioPinDriveMode.Output);
            _rtlPin.Write(GpioPinValue.Low);

        }
        public override void TurnOn(EngineDirection direction)
        {
            if (direction == EngineDirection.LeftToRight)
                _ltrPin.Write(GpioPinValue.High);

            if (direction == EngineDirection.RightToLeft)
                _rtlPin.Write(GpioPinValue.High);
        }

        public override void TurnOff()
        {
            _ltrPin.Write(GpioPinValue.Low);
            _rtlPin.Write(GpioPinValue.Low);
        }
    }
}