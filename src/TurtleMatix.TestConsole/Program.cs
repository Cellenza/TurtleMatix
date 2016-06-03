using System;
using PubNubMessaging.Core;
using TurtleMatix.Communication;
using TurtleMatix.Core;

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
                Console.Write("Console ready, waiting for instruction : ");
                key = Console.ReadLine();
                if (!key.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    queue.Publish(
                        PubNubParams.PubNubChannel,
                        ParseAlgorithme(key).ToString(), 
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

        private static TurtleAlgorithm ParseAlgorithme(string input)
        {
            var algorithm = new TurtleAlgorithm();
            var parts = input.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var command in parts)
            {
                var ops = command.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);
                algorithm.AddCommand(new TurtleCommand(ParseOperator(ops[0]), int.Parse(ops[1])));
            }
            return algorithm;
        }

        private static TurtleOperator ParseOperator(string input)
        {
            return (TurtleOperator) Enum.Parse(typeof (TurtleOperator), input);
        }

    }
}
