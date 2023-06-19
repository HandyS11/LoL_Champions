using VM.Utils;

namespace VM
{
    public class StatVM : BaseViewModel
    {
        public string Key
        {
            get => _key;
            set => SetProperty(ref _key, value);
        }
        private string _key;

        public int Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
        private int _value;
    }
}
