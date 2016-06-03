namespace Franky
{
    using System;

    using Xamarin.Forms;
    public class InstructionButton : AbsoluteLayout
    {
        public double InitialX;

        public double InitialY;

        private readonly Label label;

        public event EventHandler Selected;

        public Instruction Instruction { get; set; }

        public double Value { get; set; }

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

        public ZoneInstructions ZoneInstructions { get; set; }

        public InstructionButton()
        {
            this.HeightRequest = 50;
            this.WidthRequest = 320;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += this.OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);

            this.label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                WidthRequest = 270,
                TranslationX = 50,
            };

            this.Children.Add(this.label);
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Started)
            {
                this.InitialX = this.TranslationX;
                this.InitialY = this.TranslationY;

                this.Selected?.Invoke(this, EventArgs.Empty);
            }

            //if (Device.OS == TargetPlatform.Android)
            {
                this.ZoneInstructions.OnPanUpdated(this, e);
            }
        }
    }
}
