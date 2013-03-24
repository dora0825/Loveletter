using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HackApp
{
    public class letter
    {
        public string tem1 { get; set; }
        public ObservableCollection<string> oc_letter { get; set; }
    }
    public class letterViewModel : INotifyPropertyChanged
    {
       
        private string _tem1;
        public string Tem1
        {
            get { return _tem1; }
            set
            {
                if (value != _tem1)
                {
                    _tem1 = value;
                    RaisePropertyChanged("Tem1");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
