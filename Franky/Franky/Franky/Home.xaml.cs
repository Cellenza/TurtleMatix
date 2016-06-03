using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Franky
{
    using System.Diagnostics;

    using Microsoft.Azure.Devices.Client;

    using Newtonsoft.Json;

    using TurtleMatix.Core;

    public partial class Home : ContentPage
    {
        private readonly IAlgorithmPublisher algorithmPublisher;

        public Home()
        {
            InitializeComponent();
            this.algorithmPublisher = new PubnubAlgorithmPublisher();
            this.SizeChanged += Home_SizeChanged;
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            this.DropInstructions.HeightRequest = this.Height;
            this.DropInstructions.WidthRequest = this.Width - 350;
            this.MenuBackground.HeightRequest = this.Height;
            this.MenuBottom.TranslationY = this.Height - 59;
        }

        private async void RunClick(object sender, EventArgs e)
        {
            var turtleAlgorithm = this.DropInstructions.GetTurtleAlgorithm();

            await this.algorithmPublisher.SendAlgorithm(turtleAlgorithm);

            DispayDebugInstructions(turtleAlgorithm.Commands, 0);
        }

        private static void DispayDebugInstructions(List<TurtleCommand> instructions, int index)
        {
            foreach (var instructionDto in instructions)
            {
                Debug.WriteLine(string.Concat(Enumerable.Repeat(">", index)) + instructionDto.Operator + " " + instructionDto.Operand);

                if (instructionDto.Children != null)
                {
                    Home.DispayDebugInstructions(instructionDto.Children, index + 1);
                }
            }
        }

        private void CleanClick(object sender, EventArgs e)
        {
            this.DropInstructions.Clean();
        }
    }
}
