using System;
using PubNubMessaging.Core;
using TurtleMatix.Communication.Core;

namespace TurtleMatix.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var queue = new Pubnub(
                PubNubParams.PubNubPublisherKey,
                PubNubParams.PubNubSuscriberKey,
                PubNubParams.PubNubSecret,
                PubNubParams.PubNubCipherKey,
                true);

            queue.Publish(
                PubNubParams.PubNubInitializationChannel,
                "Initialization",
                GetResult,
                WhenErrorHandeled);

            var key = string.Empty;
            do
            {
                key = Console.ReadLine();
                if (!key.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    queue.Publish(
                        PubNubParams.PubNubChannel,
                        key, 
                        GetResult, 
                        WhenErrorHandeled);

                }

            } while (!key.Equals("exit", StringComparison.CurrentCultureIgnoreCase));

        }

        private static void GetResult(object result)
        {

        }

        private static void WhenErrorHandeled(PubnubClientError error)
        {

        }

    }
}
