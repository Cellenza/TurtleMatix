﻿using System;
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
            var turtleAlgorithm = this.DropInstructions.GetTurtleAlgorithm();

            var deviceClient = DeviceClient.CreateFromConnectionString("HostName=Franky.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=6iy0ddUa8MerZZYYH8mm2whZU4cV4kEWzacv83I/mtU=", TransportType.Http1);

            var text = JsonConvert.SerializeObject(turtleAlgorithm);
            var msg = new Message(Encoding.UTF8.GetBytes(text));

            await deviceClient.SendEventAsync(msg);

            DispayDebugInstructions(turtleAlgorithm.Commands, 0);
        }

        private static void DispayDebugInstructions(List<TurtleCommand> instructions, int index)
        {
            foreach (var instructionDto in instructions)
            {
                Debug.WriteLine(string.Concat(Enumerable.Repeat(">", index)) + instructionDto.Operator + " " + instructionDto.Operand);

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
