using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Talon : ModelBase
    {
        private Car _car;
        public Car Car
        {
            get { return GetValue<Car>(CarProperty); }
            set { SetValue(CarProperty, value); }
        }

        public static readonly PropertyData CarProperty = RegisterProperty(nameof(Car), typeof(Car), null);

        public Talon() { }
        public Talon(Car car)
        {
            _car = car;
        }
    }
}
