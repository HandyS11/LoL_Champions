using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace VM
{
    public partial class ChampionManagerVM : ObservableObject
    {
        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions { get; set; } = new ObservableCollection<ChampionVM>();

        [ObservableProperty]
        private ChampionVM selectedChampion = null;

        [ObservableProperty]
        private IDataManager dataManager;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HumanIndex))]
        [NotifyPropertyChangedFor(nameof(IsFirstPage))]
        [NotifyPropertyChangedFor(nameof(IsLastPage))]
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
            get => Index + 1 >= NbPages;
        }

        [ObservableProperty]
        private int count = 5;

        [ObservableProperty]
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
            var c = await DataManager.ChampionsMgr.GetNbItems();
            NbPages = c % Count != 0 ? c / Count + 1 : c / Count;
            var champs = await DataManager.ChampionsMgr.GetItems(Index, Count, "Name");
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
            if (await DataManager.ChampionsMgr.DeleteItem(vm.Model))
            {
                SelectedChampion = null;
                await LoadChampions();
            } 
        }

        public async Task EditChampion(ChampionVM vm)
        {
            if (await DataManager.ChampionsMgr.UpdateItem(SelectedChampion.Model, vm.Model) != null)
            {
                SelectedChampion = vm;
                await LoadChampions();
            } 
        }

        public async Task AddChampion(ChampionVM vm)
        {
            if (await DataManager.ChampionsMgr.AddItem(vm.Model) != null)
            {
                await LoadChampions();
            }     
        }
    }
}
