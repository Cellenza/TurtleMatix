using System.Threading.Tasks;

namespace TurtleMatix.Communication.Reception
{
    public interface IReceptionListener
    {
        event CommandReceivedEventHandler OnCommandReceivedEvent;
        void Initialize();
        Task StartListening();
    }
}