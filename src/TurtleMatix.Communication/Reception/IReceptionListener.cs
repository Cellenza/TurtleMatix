using System.Threading.Tasks;

namespace TurtleMatix.Communication.Reception
{
    public interface IReceptionListener
    {
        event CommandReceivedEventHandler OnCommandReceivedEvent;
        Task Initialize();
        Task StartListening();
    }
}