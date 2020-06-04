using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Test_2
{
    /// <summary>
    /// Tic-Tac-Toe MVVM ViewModel
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model = new Model();

        /// <summary>
        /// Game map
        /// </summary>
        public char[,] Map
        {
            get => this.model.Map;
        }

        //Sorry for the copypasta, I couldn't bind it normally
        public char MapElementTopLeft
            => Map[0, 0];

        public char MapElementTopMid
            => Map[0, 1];

        public char MapElementTopRight
            => Map[0, 2];

        public char MapElementMidLeft
            => Map[1, 0];
        public char MapElementMidMid
            => Map[1, 1];

        public char MapElementMidRight
            => Map[1, 2];

        public char MapElementBotLeft
            => Map[2, 0];

        public char MapElementBotMid
            => Map[2, 1];

        public char MapElementBotRight
            => Map[2, 2];
        /// <summary>
        /// Current game state
        /// </summary>
        public Model.GameState GameState
        {
            get => this.model.State;
        }

        private QuitCommand quitCommand;

        public ICommand Quit => this.quitCommand;

        private RestartCommand restartCommand;

        public ICommand Restart => this.restartCommand;

        public ViewModel()
        {
            this.quitCommand = new QuitCommand(this, model);
            this.restartCommand = new RestartCommand(this, model);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Refreshes the properties on the main window
        /// </summary>
        /// <param name="changedPropertyName"></param>
        public void UpdateControlsState(string changedPropertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
