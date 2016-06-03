using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class AzureReceptionListener : IReceptionListener
    {
        private const string DeviceConnectionString = "HostName=Franky.azure-devices.net;DeviceId=Franky;SharedAccessKey=yCSD5Eo91L8FOFKgZD/ugTZlYvAK7C3qGW1NFWV9m68=";
        private DeviceClient _deviceClient;

        public event CommandReceivedEventHandler OnCommandReceivedEvent;

        public void Initialize()
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Http1);
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