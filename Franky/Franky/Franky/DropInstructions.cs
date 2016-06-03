namespace Franky
{
    using System.Collections.Generic;

    using TurtleMatix.Core;

    using Xamarin.Forms;

    public class DropInstructions : AbsoluteLayout
    {
        private readonly GlobalInstructionCode globalInstructionCode;

        private double x1;

        private double y1;

        private double x2;

        private double y2;

        public DropInstructions()
        {
            this.globalInstructionCode = new GlobalInstructionCode(350);
            this.globalInstructionCode.TranslationY = 20;
            this.Children.Add(this.globalInstructionCode);
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            this.globalInstructionCode.HeightRequest = heightConstraint;
            this.globalInstructionCode.TranslationX = widthConstraint / 2 - 175;

            this.x1 = this.X + this.TranslationX;
            this.x2 = this.x1 + widthConstraint;
            this.y1 = this.Y + this.TranslationY;
            this.y2 = this.y1 + heightConstraint;

            return base.OnSizeRequest(widthConstraint, heightConstraint);
        }

        public bool Preview(InstructionButton instructionButton)
        {
            if (this.IsInZone(instructionButton))
            {
                return this.globalInstructionCode.Preview(instructionButton);
            }

            return false;
        }

        public void Apply(InstructionButton instructionButton)
        {
            if (this.IsInZone(instructionButton))
            {
                this.globalInstructionCode.Apply(instructionButton);
            }
        }

        private bool IsInZone(InstructionButton instructionButton)
        {
            var x = instructionButton.TranslationX;

            if (x <= this.x1) return false;
            if (x >= this.x2) return false;

            var y = instructionButton.TranslationY;

            if (y <= this.y1) return false;
            return y < this.y2;
        }

        public TurtleAlgorithm GetTurtleAlgorithm()
        {
            return new TurtleAlgorithm() { Commands = this.globalInstructionCode.GetInstructions() };
        }

        public void Clean()
        {
            this.globalInstructionCode.Clean();
        }
    }
}