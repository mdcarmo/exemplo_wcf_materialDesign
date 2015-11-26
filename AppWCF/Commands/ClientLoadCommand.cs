using AppWCF.ViewModel;
using System;
using System.Windows.Input;

namespace AppWCF.Commands
{
    public class ClientLoadCommand: ICommand
    {
        #region [ Attributes]

        private ClientViewModel _vmClient;

        #endregion

        #region [ Constructor ]

        public ClientLoadCommand(ClientViewModel vmClient)
        {
            this._vmClient = vmClient;
        }

        #endregion

        #region [ ICommand Members ]
        public bool CanExecute(object parameter)
        {
            return this._vmClient.ClienteSelecionado != null & this._vmClient.ClienteSelecionado.Cod_Cliente > 0;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this._vmClient.Cliente.Cod_Cliente = this._vmClient.ClienteSelecionado.Cod_Cliente;
            this._vmClient.Cliente.Nome = this._vmClient.ClienteSelecionado.Nome;
            this._vmClient.Cliente.Genero = this._vmClient.ClienteSelecionado.Genero;
            this._vmClient.Cliente.RG = this._vmClient.ClienteSelecionado.RG;
            this._vmClient.Cliente.CPF = this._vmClient.ClienteSelecionado.CPF;
        }
        #endregion
    }
}
