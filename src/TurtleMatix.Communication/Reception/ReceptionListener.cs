using System.Diagnostics;
using Newtonsoft.Json;
using PubNubMessaging.Core;
using TurtleMatix.Communication.Core;
using TurtleMatix.Core;

namespace TurtleMatix.Communication.Reception
{
    public class ReceptionListener
    {

        private Pubnub _pubnubMEssageQueue;

        public event CommandReceivedEventHandler OnCommandReceivedEvent;

        public void Initialize()
        {

            _pubnubMEssageQueue = new Pubnub(
                PubNubParams.PubNubPublisherKey,
                PubNubParams.PubNubSuscriberKey,
                PubNubParams.PubNubSecret,
                PubNubParams.PubNubCipherKey,
                true);

            _pubnubMEssageQueue.Subscribe<string>(
                PubNubParams.PubNubChannel,
                PubNubSubscribeSuccess,
                DisplaySubscribeConnectStatusMessage,
                PubNubError);

        }

        private void PubNubSubscribeSuccess(string inputMessage)
        {
            Debug.WriteLine("Received Message : " + inputMessage);
            dynamic input = JsonConvert.DeserializeObject(inputMessage);
            OnCommandReceivedEvent(this, new CommandReceivedEventArgs(TurtleCommand.FromString(input[0].ToString())));
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