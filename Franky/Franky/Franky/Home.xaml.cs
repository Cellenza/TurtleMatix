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

    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
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
            var instructions = this.DropInstructions.GetInstructions();

            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("<replace>", TransportType.Http1);

            var text = JsonConvert.SerializeObject(instructions);
            var msg = new Message(Encoding.UTF8.GetBytes(text));

            await deviceClient.SendEventAsync(msg);

            DispayDebugInstructions(instructions, 0);
        }

        private static void DispayDebugInstructions(List<InstructionDto> instructions, int index)
        {
            foreach (var instructionDto in instructions)
            {
                Debug.WriteLine(string.Concat(Enumerable.Repeat(">", index)) + instructionDto.Instruction + " " + instructionDto.Value);

                if (instructionDto.Children != null)
                {
                    DispayDebugInstructions(instructionDto.Children, index + 1);
                }
            }
        }

        private void CleanClick(object sender, EventArgs e)
        {
            this.DropInstructions.Clean();
        }
    }
}
