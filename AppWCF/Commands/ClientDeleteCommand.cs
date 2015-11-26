using AppWCF.Components;
using AppWCF.RepositoryMock;
using AppWCF.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppWCF.Commands
{
    public class ClientDeleteCommand: ICommand
    {
        #region ...:::Attributes:::...

        private ClientViewModel _vmClient;

        #endregion

        #region ...:::Constructor:::...

        public ClientDeleteCommand(ClientViewModel vmClient)
        {
            this._vmClient = vmClient;
        }

        #endregion

        #region ...:::ICommand Members:::...
        public bool CanExecute(object parameter)
        {
            return this._vmClient.ClienteSelecionado != null && this._vmClient.ClienteSelecionado.Cod_Cliente > 0;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public async void Execute(object parameter)
        {
          
            MessageBoxCustom messegeBox = new MessageBoxCustom();
            MessageBoxResult message = messegeBox.Show(string.Format("Tem certeza que deseja excluir o cliente: {0} ?", this._vmClient.ClienteSelecionado.Nome), "Exclusão de cliente", System.Windows.MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                var repository = new ClientRepository(this._vmClient);
                repository.Delete(this._vmClient.ClienteSelecionado);
            }
        }
        #endregion


        //private async Task showConfirmation(string message)
        //{
        //    var metroWindow = (Application.Current.MainWindow as MetroWindow);

        //    MessageDialogResult result = await metroWindow.ShowMessageAsync(message, "", MessageDialogStyle.AffirmativeAndNegative);
        //    if (result == MessageDialogResult.Affirmative)
        //    {
        //        //Do For ok Button
        //    }
        //    else
        //    {
        //        //Do For cancel Button
        //    }
        //}
    }
}
