using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class AzureReceptionListener : IReceptionListener
    {
        private const string DeviceConnectionString = "<replace>";
        private DeviceClient _deviceClient;

        public event CommandReceivedEventHandler OnCommandReceivedEvent;

        public Task Initialize()
        {
            return Task.Run(() =>
            {
                _deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString);
            });

        }

        public async Task StartListening()
        {
            await ReceiveCommands(_deviceClient);
        }

        private async Task ReceiveCommands(DeviceClient deviceClient)
        {
            while (true)
            {
                var receivedMessage = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1));
                if (receivedMessage != null)
                {
                    var messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    await deviceClient.CompleteAsync(receivedMessage);
                    OnCommandReceivedEvent?.Invoke(this,
                        new CommandReceivedEventArgs(TurtleAlgorithm.FromString(messageData)));
                }
            }
        }
    }
}