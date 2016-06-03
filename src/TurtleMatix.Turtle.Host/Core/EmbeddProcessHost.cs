using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurtleMatix.Communication.Reception;
using TurtleMatix.Core;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Core
{
    public class EmbeddProcessHost
    {
        private readonly IMovementFactory _movementFactory;

        private readonly IReceptionListener _receptionListener;

        public EmbeddProcessHost(IReceptionListener receptionListener, IMovementFactory movementFactory)
        {
            _movementFactory = movementFactory;
            _receptionListener = receptionListener;
        }

        public async Task StartProcess()
        {
            _receptionListener.OnCommandReceivedEvent += ReceptionListener_OnCommandReceivedEvent;
            _receptionListener.Initialize();
            await _receptionListener.StartListening();

        }

        private void ReceptionListener_OnCommandReceivedEvent(object sender, CommandReceivedEventArgs e)
        {
            ExecuteCommand(e.Algorithm.Commands);
        }

        private void ExecuteCommand(IEnumerable<TurtleCommand> commands, int round = 1)
        {
            for (int i = 0; i < round; i++)
            {
                foreach (var command in commands)
                {
                    if (command.Childrens != null) ExecuteCommand(command.Childrens, command.Operand);

                    var mouvement = _movementFactory.GetMovement(command.Operator);
                    mouvement.Execute(command.Operand);
                }
            }
        }
    }
}