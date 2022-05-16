using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class StationInfo : BaseViewModel
    {
        private ObservableCollection<Station> _Stationlist;
        public ObservableCollection<Station> Stationlist { get => _Stationlist; set { _Stationlist = value; OnPropertyChanged(); } }
        public StationInfo()
        {
           _Stationlist = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);
        }
    }
    
}
