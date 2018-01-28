using SMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Winclient.Models
{
    public class CustomerModel : Customer, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string Code
        {
            get => base.Code;
            set
            {
                if (this.Code != value)
                {
                    this.NotifyPropertyChanged();
                }
                base.Code = value;
            }
        }
    }
}
