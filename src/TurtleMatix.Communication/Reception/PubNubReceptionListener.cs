using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PubNubMessaging.Core;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class PubNubReceptionListener : IReceptionListener
    {
        private Pubnub _pubnubMEssageQueue;

        public event CommandReceivedEventHandler OnCommandReceivedEvent;

        public Task Initialize()
        {
            return Task.Run(() =>
            {
                _pubnubMEssageQueue = new Pubnub(
                    PubNubParams.PubNubPublisherKey,
                    PubNubParams.PubNubSuscriberKey,
                    PubNubParams.PubNubSecret,
                    PubNubParams.PubNubCipherKey,
                    true);
            });
        }

        public Task StartListening()
        {
            return Task.Run(() =>
            {
                _pubnubMEssageQueue.Subscribe<string>(
                    PubNubParams.PubNubChannel,
                    PubNubSubscribeSuccess,
                    DisplaySubscribeConnectStatusMessage,
                    PubNubError);

            });
        }

        private void PubNubSubscribeSuccess(string inputMessage)
        {
            Debug.WriteLine("Received Message : " + inputMessage);
            dynamic input = JsonConvert.DeserializeObject(inputMessage);
            OnCommandReceivedEvent?.Invoke(this, new CommandReceivedEventArgs(TurtleAlgorithm.FromString(input[0].ToString())));
        }

        private void DisplaySubscribeConnectStatusMessage(string publishResult)
        {
            Debug.WriteLine("Connection: " + publishResult);
        }

        private void PubNubError(PubnubClientError error)
        {
            Debug.WriteLine("ERROR CATCHED: " + error);
        }
    }
}