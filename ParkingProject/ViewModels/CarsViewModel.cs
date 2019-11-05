﻿namespace Parking.ViewModels
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
    using System.Threading;
    using System.Threading.Tasks;

    public class CarsViewModel : ViewModelBase
    {
        private IUIVisualizerService _uiVisualizerService;
        public CarsViewModel(/* dependency injection here */IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;
            CarsCollection = new ObservableCollection<Car>
            {
                new Car() { Number = "1", Model = "1", Color="1" },
                new Car() { Number = "2", Model = "2", Color="2" }
            };
        }


        public ObservableCollection<Car> CarsCollection
        {
            get { return GetValue<ObservableCollection<Car>>(CarsCollectionProperty); }
            set { SetValue(CarsCollectionProperty, value); }
        }
        public static readonly PropertyData CarsCollectionProperty = RegisterProperty(nameof(CarsCollection), typeof(ObservableCollection<Car>), null);


        public Car SelectedCar
        {
            get { return GetValue<Car>(SelectedCarProperty); }
            set { SetValue(SelectedCarProperty, value); }
        }
        public static readonly PropertyData SelectedCarProperty = RegisterProperty(nameof(SelectedCar), typeof(Car), null);


        private Command _addCar;
        public Command AddCar
        {
            get
            {
                return _addCar ?? (_addCar = new Command(() =>
                {
                    var viewModel = new CarViewModel();

                    _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            CarsCollection.Add(viewModel.CarObject);
                        }
                    });
                }));
            }
        }


        private Command _editCar;
        public Command EditCar
        {
            get
            {
                return _editCar ?? (_editCar = new Command(() =>
                {
                    var viewModel = new CarViewModel(SelectedCar);
                    _uiVisualizerService.ShowDialog(viewModel);
                },
                () => SelectedCar != null));
            }
        }


        private Command _removeCar;
        public Command RemoveCar
        {
            get
            {
                    return _removeCar ?? (_removeCar = new Command(async () =>
                    {
                        CarsCollection.Remove(SelectedCar);                        
                    },
                    () => SelectedCar != null));
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
