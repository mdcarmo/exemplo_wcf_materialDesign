using AppWCF.ViewModel;
using System;
using System.Windows.Input;

namespace AppWCF.Commands
{
    public class ClientCancelCommand : ICommand
    {
        #region [ Attributes ]

        private ClientViewModel _vmClient;

        #endregion

        #region [ Constructor ]

        public ClientCancelCommand(ClientViewModel vmClient)
        {
            this._vmClient = vmClient;
        }

        #endregion

        #region [ ICommand Members ]
        public bool CanExecute(object parameter)
        {
            return this.verificaCancelamento();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this._vmClient.LimparAtual();
        }
        #endregion

        #region [ Method's ]
        /// <summary>
        /// Verifica se existe dados preenchido na tela para realizar o cancelamento
        /// </summary>
        /// <returns>Retorna true caso tenha algum campo preenchido na tela</returns>
        private bool verificaCancelamento()
        {
            bool validar = false;
            if (!string.IsNullOrEmpty(this._vmClient.Cliente.Nome))
                validar = true;
            if (!string.IsNullOrEmpty(this._vmClient.Cliente.CPF))
                validar = true;
            if (!string.IsNullOrEmpty(this._vmClient.Cliente.RG))
                validar = true;
            if (this._vmClient.Cliente.Genero != null && this._vmClient.Cliente.Genero.Codigo > 0)
                validar = true;
            return validar;
        }
        #endregion
    }
}
