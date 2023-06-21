using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private ChampionVM selectedChampion = new(new Champion(""));

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

        public ChampionManagerVM(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);

            PreviousPageCommand = new Command(async () => await LoadPage(false),
                                              () => !IsFirstPage);
            NextPageCommand = new Command(async () => await LoadPage(true),
                                          () => !IsLastPage);
        }

        [RelayCommand]
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

        [RelayCommand]
        public async Task DeleteChampion(ChampionVM vm)
        {
            if (await DataManager.ChampionsMgr.DeleteItem(vm.Model))
            {
                SelectedChampion = null;
                await LoadChampions();
            } 
        }

        [RelayCommand]
        public async Task EditChampion(ChampionVM vm)
        {
            if (await DataManager.ChampionsMgr.UpdateItem(SelectedChampion.Model, vm.Model) != null)
            {
                SelectedChampion = vm;
                await LoadChampions();
            } 
        }

        [RelayCommand]
        public async Task AddChampion(ChampionVM vm)
        {
            if (await DataManager.ChampionsMgr.AddItem(vm.Model) != null)
            {
                SelectedChampion = vm;
                await LoadChampions();
            }     
        }
    }
}
