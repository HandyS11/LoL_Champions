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

        public ChampionVM SelectedChampion
        {
            get => selectChampion;
            set => SetProperty(ref selectChampion, value);
        }
        private ChampionVM selectChampion = new(new Champion(""));

        public IDataManager DataManager
        {
            get => dataManager;
            set => SetProperty(ref dataManager, value);
        }
        private IDataManager dataManager;

        public int Index
        {
            get => index;
            set
            {
                SetProperty(ref index, value);
                OnPropertyChanged(nameof(HumanIndex));
                OnPropertyChanged(nameof(IsFirstPage));
                OnPropertyChanged(nameof(IsLastPage));
            }
        }
        private int index = 0;

        public int HumanIndex
        {
            get => Index + 1;
        }

        public bool IsFirstPage
        {
            get => Index <= 0;
        }

        public bool IsLastPage
        {
            get => Index + 1 >= nbPages;
        }

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
        private int nbPages = 99;

        public ICommand PreviousPageCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }
        public ICommand LoadChampionsCommand { get; private set; }

        public ICommand DeleteChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }
        public ICommand AddChampionCommand { get; private set; }

        public ChampionManagerVM(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);

            PreviousPageCommand = new Command(async () => await LoadPage(false),
                                              () => !IsFirstPage);
            NextPageCommand = new Command(async () => await LoadPage(true),
                                          () => !IsLastPage);            

            LoadChampionsCommand = new Command(async () => await LoadChampions());

            DeleteChampionCommand = new Command<ChampionVM>(async (vm) => await DeleteChampion(vm));
            EditChampionCommand = new Command<ChampionVM>(async (vm) => await EditChampion(vm));
            AddChampionCommand = new Command<ChampionVM>(async (vm) => await AddChampion(vm));
        }

        private async Task LoadChampions()
        {
            champions.Clear();
            var c = await dataManager.ChampionsMgr.GetNbItems();
            NbPages = c % Count != 0 ? c / Count + 1 : c / Count;
            var champs = await dataManager.ChampionsMgr.GetItems(Index, Count, "Name");
            foreach(var champ in champs)
            {
                champions.Add(new ChampionVM(champ));
            }
        }

        private async Task LoadPage(bool upOrDown)
        {
            if (upOrDown)
            {
                if (Index + 1 >= NbPages) return;
                Index++;             
            }
            else
            {
                if (Index <= 0) return;
                Index--;     
            }
            (PreviousPageCommand as Command).ChangeCanExecute();
            (NextPageCommand as Command).ChangeCanExecute();
            await LoadChampions();
        }

        public async Task DeleteChampion(ChampionVM vm)
        {
            if (await dataManager.ChampionsMgr.DeleteItem(vm.Model))
            {
                SelectedChampion = null;
                await LoadChampions();
            } 
        }

        public async Task EditChampion(ChampionVM vm)
        {
            if (await dataManager.ChampionsMgr.UpdateItem(SelectedChampion.Model, vm.Model) != null)
            {
                SelectedChampion = vm;
                await LoadChampions();
            } 
        }

        public async Task AddChampion(ChampionVM vm)
        {
            if (await dataManager.ChampionsMgr.AddItem(vm.Model) != null)
            {
                SelectedChampion = vm;
                await LoadChampions();
            }     
        }
    }
}
