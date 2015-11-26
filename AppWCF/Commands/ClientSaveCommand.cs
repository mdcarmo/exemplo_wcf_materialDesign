using AppWCF.Model;
using AppWCF.RepositoryMock;
using AppWCF.ViewModel;
using System;
using System.Windows.Input;

namespace AppWCF.Commands
{
    public class ClientSaveCommand : ICommand
    {
        #region [ Attributes ]
        /// <summary>
        /// ViewModel a qual foi chamado o evento
        /// </summary>
        private ClientViewModel _vmClient;

        #endregion

        #region [ Constructor ]
        /// <summary>
        /// Construtor contendo a VMCliente
        /// </summary>
        /// <param name="vmCliente">VMCliente que ira dispara o evento</param>
        public ClientSaveCommand(ClientViewModel vmClient)
        {
            this._vmClient = vmClient;
        }

        #endregion

        #region [ ICommand Members ]

        public bool CanExecute(object parameter)
        {
            return this.Validation();
        }

        /// <summary>
        /// Evento verifica a cada instante o CanExecute sem isso o canexcute tem que retornar sempre true se não ele ficara desabilitado
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            var cliente = new ClientModel();
            cliente.Cod_Cliente = this._vmClient.Cliente.Cod_Cliente;
            cliente.Nome = this._vmClient.Cliente.Nome;
            cliente.RG = this._vmClient.Cliente.RG;
            cliente.CPF = this._vmClient.Cliente.CPF;
            cliente.Genero = this._vmClient.Cliente.Genero;

            var repository = new ClientRepository(this._vmClient);
            if (cliente.Cod_Cliente > 0)
                repository.Update(cliente);
            else
                repository.Insert(cliente);
            this._vmClient.LimparAtual();
        }

        #endregion

        #region [ Methods ]
        private bool Validation()
        {
            bool validar = true;
            if (string.IsNullOrEmpty(this._vmClient.Cliente.Nome))
                validar = false;
            if (string.IsNullOrEmpty(this._vmClient.Cliente.CPF))
                validar = false;
            if (string.IsNullOrEmpty(this._vmClient.Cliente.RG))
                validar = false;
            if (this._vmClient.Cliente != null && this._vmClient.Cliente.Genero != null && this._vmClient.Cliente.Genero.Codigo <= 0)
                validar = false;
            return validar;
        } 
        #endregion
    }
}
