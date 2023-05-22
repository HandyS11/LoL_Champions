using Model;
using System.Collections.ObjectModel;
using VM.Utils;

namespace VM
{
    public class ChampionManagerVM : BaseViewModel
    {
        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions { get; set; }

        public IDataManager DataManager
        {
            get => dataManager;
            set => SetProperty(ref dataManager, value);
        }
        private IDataManager dataManager;

        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }
        private int index;

        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }
        private int count = 5;

        public ChampionManagerVM(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
