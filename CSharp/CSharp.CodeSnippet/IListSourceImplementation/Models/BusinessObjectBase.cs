using System.ComponentModel;

namespace IListSourceImplementation.Models
{
    public class BusinessObjectBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) {
                PropertyChangedEventHandler firePropertyChangedEvent = PropertyChanged;
                firePropertyChangedEvent(this, e);
            }
        }

        #endregion
    }
}
