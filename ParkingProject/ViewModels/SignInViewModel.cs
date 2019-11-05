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
    using System.Threading.Tasks;

    public class SignInViewModel : ViewModelBase
    {
        public SignInViewModel(/* dependency injection here */)
        {
        }

        public override string Title { get { return "Sign In"; } }

        public string Login
        {
            get { return GetValue<string>(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly PropertyData LoginProperty = RegisterProperty(nameof(Login), typeof(string), null);

        public string Pass
        {
            get { return GetValue<string>(PassProperty); }
            set { SetValue(PassProperty, value); }
        }        
        public static readonly PropertyData PassProperty = RegisterProperty(nameof(Pass), typeof(string), null);


        public Command SignIn
        {
            get
            {
                return new Command(() =>
                {
                    CheckPass();
                });
            }
        }
        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        private async void CheckPass()
        {
            if (Login == "Login" && Pass == "Password")
                await base.CloseAsync();
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
