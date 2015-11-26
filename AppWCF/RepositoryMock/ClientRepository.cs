using AppWCF.Model;
using AppWCF.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppWCF.RepositoryMock
{
    public class ClientRepository
    {
        /// <summary>
        /// terá a ViewModel que estanciou a repositorio
        /// </summary>
        private ClientViewModel _vmCliente;

        /// <summary>
        /// Construtor para receber a ViewModel de Cliente
        /// </summary>
        /// <param name="vmCliente">VMCliente que foi chamado</param>
        public ClientRepository(ClientViewModel vmCliente)
        {
            _vmCliente = vmCliente;
        }

        /// <summary>
        /// Ira inserir na propriedade de Clientes da VMCliente
        /// </summary>
        /// <param name="entity">Cliente a ser adicionado na lista</param>
        public void Insert(ClientModel entity)
        {
            ObservableCollection<ClientModel> list = _vmCliente.Clientes;
            entity.Cod_Cliente = this._vmCliente.Clientes.Count() + 1;
            list.Add(entity);
        }

        /// <summary>
        /// Ira deletar o cliente da lista de Clientes
        /// </summary>
        /// <param name="entity">Cliente a ser deletado</param>
        public void Delete(ClientModel entity)
        {
            ObservableCollection<ClientModel> list = _vmCliente.Clientes;
            list.Remove(entity);
        }

        /// <summary>
        /// Ira atualizar o registro informado na lista de clientes
        /// </summary>
        /// <param name="entity">Cliente a ser alterado</param>
        public void Update(ClientModel entity)
        {
            ObservableCollection<ClientModel> list = _vmCliente.Clientes;
            ClientModel client = _vmCliente.Clientes.FirstOrDefault(x => x.Cod_Cliente == entity.Cod_Cliente);
            list.Remove(client);
            list.Add(entity);
        }
    }
}
