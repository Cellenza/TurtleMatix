using TurtleMatix.Communication.Reception;
using TurtleMatix.Turtle.Application.Generic;

namespace TurtleMatix.Turtle.Host.Core
{
    public class EmbeddProcessHost
    {
        private readonly _IMouvementFactory _mouvementFactory;

        private readonly ReceptionListener _receptionListener;

        public EmbeddProcessHost(_IMouvementFactory mouvementFactory)
        {
            _mouvementFactory = mouvementFactory;
            _receptionListener = new ReceptionListener();
        }

        public void StartProcess()
        {
            _receptionListener.OnCommandReceivedEvent += ReceptionListener_OnCommandReceivedEvent;
            _receptionListener.Initialize();

        }

        private void ReceptionListener_OnCommandReceivedEvent(object sender, CommandReceivedEventArgs e)
        {
            foreach (var command in e.Algorithm.Commands)
            {
                var mouvement = _mouvementFactory.GetMouvement(command.Operator);
                mouvement.Execute(command.Operand);
            }
        }

    }
}