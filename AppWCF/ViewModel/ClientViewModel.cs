using AppWCF.Base;
using AppWCF.Commands;
using AppWCF.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppWCF.ViewModel
{
    public class ClientViewModel : ModelBase
    {
        /// <summary>
        /// Contrutor para inicializar os objetos da tela
        /// </summary>
        public ClientViewModel()
        {
            this.Initialize();
        }

        #region [ Properties ]
        ObservableCollection<ClientModel> _Clientes = new ObservableCollection<ClientModel>();
        /// <summary>
        /// Lista aonde encontrar os clientes
        /// </summary>
        public ObservableCollection<ClientModel> Clientes
        {
            get { return _Clientes; }
            set { _Clientes = value; this.NotifyPropertyChanged("Clientes"); }
        }

        private ClientModel _Cliente = new ClientModel();
        /// <summary>
        /// Cliente a ser exibido nos campos da tela
        /// </summary>
        public ClientModel Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private ClientModel _ClienteSelecionado = new ClientModel();
        /// <summary>
        /// Cliente no qual esta selecionado no Grid
        /// </summary>
        public ClientModel ClienteSelecionado
        {
            get { return _ClienteSelecionado; }
            set { _ClienteSelecionado = value; this.NotifyPropertyChanged("ClienteSelecionado"); }
        }

        private List<GenreModel> _lGenero = new List<GenreModel>();
        /// <summary>
        /// Lista de generos
        /// </summary>
        public List<GenreModel> lGenero
        {
            get { return _lGenero; }
            set { _lGenero = value; this.NotifyPropertyChanged("lGenero"); }
        }
        #endregion

        #region [ Commands]

        /// <summary>
        /// Command para carregar o objeto selecionado para a alteração
        /// </summary>
        public ICommand DoubleClickCommand { get; set; }

        /// <summary>
        /// Ira salvar o cliente que esta sendo exibido no campo
        /// </summary>
        public ICommand Salvar { get; set; }

        /// <summary>
        /// deleta cliente selecionado
        /// </summary>
        public ICommand Deletar { get; set; }

        /// <summary>
        /// Limpa os dados de exibição
        /// </summary>
        public ICommand Limpar { get; set; }

        #endregion

        #region [ Method's ]
        private void Initialize()
        {
            this.DoubleClickCommand = new ClientLoadCommand(this);
            this.Salvar = new ClientSaveCommand(this);
            this.Limpar = new ClientCancelCommand(this);
            this.Deletar = new ClientDeleteCommand(this);

            this.CarregarGeneros();
            this.LimparAtual();
        }

        public void LimparAtual()
        {
            this.Cliente.Cod_Cliente = 0;
            this.Cliente.Nome = string.Empty;
            this.Cliente.Genero = null;
            this.Cliente.RG = string.Empty;
            this.Cliente.CPF = string.Empty;
            this.Cliente.Genero = null;
        }

        /// <summary>
        /// Carrega os generos a ser selecionado para o Cliente
        /// </summary>
        public void CarregarGeneros()
        {
            lGenero.Add(new GenreModel { Codigo = 1, Descr = "Masculino" });
            lGenero.Add(new GenreModel { Codigo = 2, Descr = "Feminino" });
        }
        #endregion
    }
}
