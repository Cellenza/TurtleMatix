namespace TurtleMatix.Turtle.Application.Generic
{
    public abstract class AbstractDirectMouvement : _IMouvement
    {
        public const int TenCentimeterMouvementDuration = 5000;

        public abstract void Execute(int value);

        protected int CalculateRuntime(int input)
        {
            return (input * TenCentimeterMouvementDuration) / 10;
        }

    }
}