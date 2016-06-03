namespace Franky
{
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Azure.Devices.Client;

    using Newtonsoft.Json;

    using PubNubMessaging.Core;

    using TurtleMatix.Core;

    public interface IAlgorithmPublisher
    {
        Task SendAlgorithm(TurtleAlgorithm turtleAlgorithm);
    }
    public class PubNubParams
    {
        public static string PubNubPublisherKey => "pub-c-9d4bbb5f-e04d-497b-b648-dab9ea196b4f";
        public static string PubNubSuscriberKey => "sub-c-b0594c30-5bfa-11e5-9c33-02ee2ddab7fe";
        public static string PubNubSecret => "sec-c-YjRkNzE1MzctNTQ5NC00ODEzLTkwYjgtYWI4MmYxODY2ZWNk";
        public static string PubNubCipherKey => "azerty123#";
        public static string PubNubChannel => "Cellenza-TurtleMatix";
        public static string PubNubInitializationChannel => "Cellenza-TurtleMatix-Initialization";
    }


    class PubnubAlgorithmPublisher : IAlgorithmPublisher
    {
        private Pubnub queue;

        public PubnubAlgorithmPublisher()
        {
            queue = new Pubnub(
             PubNubParams.PubNubPublisherKey,
             PubNubParams.PubNubSuscriberKey,
             PubNubParams.PubNubSecret,
             PubNubParams.PubNubCipherKey,
             true);

            this.queue.Publish(
                PubNubParams.PubNubInitializationChannel,
                "Initialization",
                this.GetResult,
                this.WhenErrorHandeled);
        }

        private void WhenErrorHandeled(PubnubClientError obj)
        {
            Debug.WriteLine("Error to send message : " + obj.Message);
        }

        private void GetResult(object obj)
        {
            Debug.WriteLine("Message send !");
        }

        public Task SendAlgorithm(TurtleAlgorithm turtleAlgorithm)
        {
            var text = JsonConvert.SerializeObject(turtleAlgorithm);

            return Task.Run(
                () =>
                    {
                        this.queue.Publish(
                           PubNubParams.PubNubChannel,
                           text,
                           GetResult,
                           WhenErrorHandeled);

                    });
        }
    }

    public class AlgorithmPublisher : IAlgorithmPublisher
    {
        public async Task SendAlgorithm(TurtleAlgorithm turtleAlgorithm)
        {
            var deviceClient =
                DeviceClient.CreateFromConnectionString(
                    "HostName=Franky.azure-devices.net;DeviceId=Franky;SharedAccessKey=yCSD5Eo91L8FOFKgZD/ugTZlYvAK7C3qGW1NFWV9m68=",
                    TransportType.Http1);

            var text = JsonConvert.SerializeObject(turtleAlgorithm);
            var msg = new Message(Encoding.UTF8.GetBytes(text));

            await deviceClient.SendEventAsync(msg);
        }
    }
}