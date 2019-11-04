using System.Threading.Tasks;

namespace Parking.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Catel;
    using Catel.Collections;
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using Parking.Models;
    using Parking.Views;
    using WPF.GettingStarted.Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;

        private readonly IViewModel carsViewModel;
        private readonly IViewModel feedBackViewModel;
        private readonly IViewModel signInViewModel;
        private readonly IViewModel talonsViewModel;
        private readonly IViewModel userViewModel;

        public override string Title { get { return "Parking"; } }

        public IViewModel CurrentViewModel
        {
            get { return GetValue<IViewModel>(CurrentViewModelProperty); }
            set { SetValue(CurrentViewModelProperty, value); }
        }
        public static readonly PropertyData CurrentViewModelProperty = RegisterProperty(nameof(CurrentViewModel), typeof(IViewModel), null);

        public double OpacityView
        {
            get { return GetValue<double>(OpacityViewProperty); }
            set { SetValue(OpacityViewProperty, value); }
        }
        public static readonly PropertyData OpacityViewProperty = RegisterProperty(nameof(OpacityView), typeof(double), null);

        public Command ShowUserView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(userViewModel);
                });
            }
        }
        public Command ShowCarsView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(carsViewModel);
                });
            }
        }
        public Command ShowTalonsView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(talonsViewModel);
                });
            }
        }
        public Command ShowFeedBackView
        {
            get
            {
                return new Command(() =>
                {
                    SlowChangeView(feedBackViewModel);
                });
            }
        }
        
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            carsViewModel = new CarsViewModel();
            feedBackViewModel = new FeedBackViewModel();
            signInViewModel = new SignInViewModel();
            talonsViewModel = new TalonsViewModel();
            userViewModel = new UserViewModel();

            var a = new SignInView();
            a.ShowDialog();

            CurrentViewModel = userViewModel;
        }

        private async void SlowChangeView(IViewModel newViewModel)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1; OpacityView > 0; i -= 0.2)
                {
                    OpacityView = i;
                    ThreadHelper.Sleep(25);
                }
                CurrentViewModel = newViewModel;
                for (double i = 0; OpacityView <= 1.1; i += 0.2)
                {
                    OpacityView = i;
                    ThreadHelper.Sleep(25);
                }
            });
            
        }

        protected override Task CloseAsync()
        {
            return base.CloseAsync();
        }
        protected override Task InitializeAsync()
        {
            return base.InitializeAsync();
        }
    }
}
