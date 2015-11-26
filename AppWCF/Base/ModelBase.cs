using System.ComponentModel;

namespace AppWCF.Base
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifica que houve alteração no campo informado
        /// </summary>
        /// <param name=”campo”>Campo aonde houve alteração</param>
        protected void NotifyPropertyChanged(string campo)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(campo));
            }
        }
    }
}
