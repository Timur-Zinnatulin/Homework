using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_2
{
    /// <summary>
    /// Restart the game command
    /// </summary>
    public class RestartCommand : ICommand
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private ViewModel viewModel;

        /// <summary>
        /// Model
        /// </summary>
        private Model model;

        public event EventHandler CanExecuteChanged;

        public RestartCommand(ViewModel vm, Model m)
        {
            this.viewModel = vm;
            this.model = m;
        }

        public bool CanExecute(object a)
        {
            return viewModel != null;
        }

        /// <summary>
        /// Restarts the game
        /// </summary>
        /// <param name="a"></param>
        public void Execute(object a)
        {
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location); 
            System.Windows.Application.Current.Shutdown();
        }
    }
}
