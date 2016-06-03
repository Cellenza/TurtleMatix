using Windows.UI.Xaml.Controls;
using TurtleMatix.Communication.Reception;
using TurtleMatix.Turtle.Application.Generic;
using TurtleMatix.Turtle.Host.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TurtleMatix.Turtle.Host
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly EmbeddProcessHost _host;
        public MainPage()
        {
            InitializeComponent();

            _host = new EmbeddProcessHost(new PubNubReceptionListener(), new MovementFacotry(new EngineFactory()));
            _host.StartProcess().Wait();
        }
    }
}
