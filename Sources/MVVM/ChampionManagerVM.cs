using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VM.Utils;

namespace VM
{
    public class ChampionManagerVM : BaseViewModel
    {
        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions { get; set; } = new ObservableCollection<ChampionVM>();

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
        private int index = 0;

        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }
        private int count = 5;

        public int NbPages
        {
            get => nbPages;
            set => SetProperty(ref nbPages, value);
        }
        private int nbPages = 2;

        public ICommand ChangePageCommand { get; private set; }
        public ICommand LoadChampionsCommand { get; private set; }

        public ChampionManagerVM(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);

            ChangePageCommand = new Command<bool>(async (b) => await LoadPage(b));
            LoadChampionsCommand = new Command(async () => await LoadChampions());
        }

        public async Task LoadChampions()
        {
            champions.Clear();
            NbPages = await dataManager.ChampionsMgr.GetNbItems() / Count;
            var champs = await dataManager.ChampionsMgr.GetItems(Index, Count);
            foreach(var champ in champs)
            {
                champions.Add(new ChampionVM(champ));
            }
        }

        private async Task LoadPage(bool upOrDown)
        {
            if (upOrDown)
            {
                if (Index >= NbPages) return;
                Index++;
            }
            else
            {
                if (Index <= 0) return;
                Index--;                
            }
            await LoadChampions();
        }
    }
}
