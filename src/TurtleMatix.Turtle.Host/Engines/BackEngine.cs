using Windows.Devices.Gpio;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Engines
{
    public class BackEngine : _IEngine
    {
        private readonly GpioPin _ltrPin;
        private readonly GpioPin _rtlPin;
        public BackEngine()
        {
            var controller = GpioController.GetDefault();

            _ltrPin = controller.OpenPin(26);
            _ltrPin.SetDriveMode(GpioPinDriveMode.Output);
            _ltrPin.Write(GpioPinValue.Low);

            _rtlPin = controller.OpenPin(12);
            _rtlPin.SetDriveMode(GpioPinDriveMode.Output);
            _rtlPin.Write(GpioPinValue.Low);

        }
        public void TurnOn(EngineDirection direction)
        {
            if(direction == EngineDirection.LeftToRight)
                _ltrPin.Write(GpioPinValue.High);

            if (direction == EngineDirection.RightToLeft)
                _rtlPin.Write(GpioPinValue.High);
        }

        public void TurnOff()
        {
            _ltrPin.Write(GpioPinValue.Low);
            _rtlPin.Write(GpioPinValue.Low);
        }
    }
}