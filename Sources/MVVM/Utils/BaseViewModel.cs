using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Utils
{
    public class BaseViewModel
    {
        /// <summary>
        /// Update the existing data and notify the change
        /// </summary>
        /// <typeparam name="T"> Object type </typeparam>
        /// <param name="backingStore"> Stored data </param>
        /// <param name="value"> Data </param>
        /// <param name="propertyName"> Property name </param>
        /// <param name="onChanged"> Action </param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Invoke the property change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
