using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_2
{
    /// <summary>
    /// Quit command
    /// </summary>
    public class QuitCommand : ICommand
    {
        /// <summary>
        /// MVVM ViewModel
        /// </summary>
        private ViewModel viewModel;

        /// <summary>
        /// MVVM Model
        /// </summary>
        private Model model;

        public event EventHandler CanExecuteChanged;

        public QuitCommand(ViewModel vm, Model m)
        {
            this.viewModel = vm;
            this.model = m;
        }

        public bool CanExecute(object a)
        {
            return viewModel != null;
        }

        /// <summary>
        /// Quits the game
        /// </summary>
        /// <param name="a"></param>
        public void Execute(object a)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
