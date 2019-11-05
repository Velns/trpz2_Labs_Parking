namespace Parking.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Parking.Models;
    using System.Threading.Tasks;

    public class TalonViewModel : ViewModelBase
    {
        public TalonViewModel(/* dependency injection here */)
        {
        }

        public override string Title { get { return "View model title"; } }


        [Model]
        public Talon TalonObject
        {
            get { return GetValue<Talon>(TalonObjectProperty); }
            private set { SetValue(TalonObjectProperty, value); }
        }

        public static readonly PropertyData TalonObjectProperty = RegisterProperty(nameof(TalonObject), typeof(Talon));        
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

        public TalonViewModel(Talon talon = null)
        {
            TalonObject = talon ?? new Talon();
        }
    }
}
