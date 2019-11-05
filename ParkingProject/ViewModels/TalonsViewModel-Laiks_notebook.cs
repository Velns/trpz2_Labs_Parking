namespace Parking.ViewModels
{
    using Catel.MVVM;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Parking.Models;
    using Catel.Data;
    using Catel.Services;

    public class TalonsViewModel : ViewModelBase
    {
        private IUIVisualizerService _uiVisualizerService;
        public TalonsViewModel(/* dependency injection here */IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;
            TalonsCollection = new ObservableCollection<Talon>();
        }

        public ObservableCollection<Talon> TalonsCollection
        {
            get { return GetValue<ObservableCollection<Talon>>(TalonsCollectionProperty); }
            set { SetValue(TalonsCollectionProperty, value); }
        }   
        public static readonly PropertyData TalonsCollectionProperty = RegisterProperty(nameof(TalonsCollection), typeof(ObservableCollection<Talon>), null);
        

        private Command _addTalon;
        public Command AddTalon
        {
            get
            {
                return _addTalon ?? (_addTalon = new Command(() =>
                {
                    var viewModel = new TalonViewModel();

                    _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            TalonsCollection.Add(viewModel.TalonObject);
                        }
                    });
                }));
            }
        }
        
        public Talon SelectedTalon
        {
            get { return GetValue<Talon>(SelectedTalonProperty); }
            set { SetValue(SelectedTalonProperty, value); }
        }

        public static readonly PropertyData SelectedTalonProperty = RegisterProperty(nameof(SelectedTalon), typeof(Talon), null);

        private Command _editTalon;
        public Command EditTalon
        {
            get
            {
                return _editTalon ?? (_editTalon = new Command(() =>
                {
                    var viewModel = new TalonViewModel(SelectedTalon);
                    _uiVisualizerService.ShowDialog(viewModel);
                },
                () => SelectedTalon != null));
            }
        }


        private Command _removeTalon;
        public Command RemoveTalon
        {
            get
            {
                return _removeTalon ?? (_removeTalon = new Command(async () =>
                {
                    //TalonsCollection.Remove(SelectedTalon);
                },
                () => SelectedTalon != null));
            }
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }
        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
