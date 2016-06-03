namespace Franky
{
    using TurtleMatix.Core;

    using Xamarin.Forms;

    public class InstructionCode : AbsoluteLayout
    {
        private readonly Label label;

        public InstructionCode(double width)
        {
            this.WidthRequest = width;
            this.HeightRequest = 50;

            this.label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                WidthRequest = width,
                TranslationX = 50,
            };

            this.Children.Add(this.label);
        }
        public void SetFromInstructionButton(InstructionButton instructionButton)
        {
            this.BackgroundColor = instructionButton.BackgroundColor;
            this.Text = instructionButton.Text;
            this.Instruction = instructionButton.Instruction;
            this.Value = instructionButton.Value;
        }

        public int Value { get; set; }

        public TurtleOperator Instruction { get; set; }

        public string Text
        {
            get
            {
                return this.label.Text;
            }
            set
            {
                this.label.Text = value;
            }
        }

        public bool IsOnInstruction(double position)
        {
            return position > this.TranslationY && position < this.TranslationY + 50;
        }
    }
}