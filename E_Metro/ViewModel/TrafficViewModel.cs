using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class TrafficViewModel : BaseViewModel
    {
        
        public static ObservableCollection<Company> myList1 { get; set; }
        
        public static ObservableCollection<Station> myList2 { get; set; }

        public TrafficViewModel()
        {
            myList1 = new ObservableCollection<Company>(DataProvider.Ins.DB.Companies);
            myList2 = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);
        }
    }
}
