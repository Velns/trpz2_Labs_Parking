using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace Parking.Models
{
    public class User : ModelBase
    {

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        public string PhoneNum
        {
            get { return GetValue<string>(PhoneNumProperty); }
            set { SetValue(PhoneNumProperty, value); }
        }
        public static readonly PropertyData PhoneNumProperty = RegisterProperty(nameof(PhoneNum), typeof(string), null);
    }
}
