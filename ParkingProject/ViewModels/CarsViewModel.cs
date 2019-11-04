namespace Parking.ViewModels
{
    using Catel;
    using Catel.Collections;
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using Parking.Models;
    using Parking.Views;
using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class CarsViewModel : ViewModelBase
    {
        public CarsViewModel(/* dependency injection here */)
        {
            UserList = new ObservableCollection<User>
            {
                new User() { Name = "1", PhoneNum = "1" },
                new User() { Name = "2", PhoneNum = "2" }
            };
        }

        public ObservableCollection<User> UserList { get; set; }

        public override string Title { get { return "View model title"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        
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
