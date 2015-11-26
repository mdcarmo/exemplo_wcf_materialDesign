using AppWCF.Base;

namespace AppWCF.Model
{
    public class GenreModel : ModelBase
    {
        private int _Codigo;
        /// <summary>
        /// Codigo para cada genero
        /// </summary>
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; this.NotifyPropertyChanged("Codigo"); }
        }
        private string _Descr;
        /// <summary>
        /// Descrição do genero
        /// </summary>
        public string Descr
        {
            get { return _Descr; }
            set { _Descr = value; this.NotifyPropertyChanged("Descr"); }
        }
    }
}
