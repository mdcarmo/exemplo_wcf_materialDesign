using AppWCF.Base;

namespace AppWCF.Model
{
    public class ClientModel : ModelBase
    {
        private int _Cod_Cliente;
        /// <summary>
        /// Código do cliente
        /// </summary>
        public int Cod_Cliente
        {
            get { return _Cod_Cliente; }
            set { _Cod_Cliente = value; this.NotifyPropertyChanged("Cod_Cliente"); }
        }
        private string _Nome;
        /// <summary>
        /// Nome a ser visualizado
        /// </summary>
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; this.NotifyPropertyChanged("Nome"); }
        }
        private GenreModel _Genero;
        /// <summary>
        /// Genero do cliente Masculino ou Feminino
        /// </summary>
        public GenreModel Genero
        {
            get { return _Genero; }
            set { _Genero = value; this.NotifyPropertyChanged("lGenero"); }
        }
        private string _RG;
        /// <summary>
        /// Numero de Identidade
        /// </summary>
        public string RG
        {
            get { return _RG; }
            set { _RG = value; this.NotifyPropertyChanged("RG"); }
        }
        private string _CPF;
        /// <summary>
        /// CPF do Cliente
        /// </summary>
        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; this.NotifyPropertyChanged("CPF"); }
        }
    }
}
