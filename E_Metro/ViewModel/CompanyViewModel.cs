using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Metro.ViewModel
{
    class CompanyViewModel : BaseViewModel
    {

        public static ObservableCollection<RailWay> myList { get; set; }

        private ObservableCollection<Station> _staionList;
        public ObservableCollection<Station> staionList { get => _staionList; set { _staionList = value; OnPropertyChanged(); } }

        public int code = LoginViewModel.idOCom;       


        public CompanyViewModel()
        {

            if (code != 0)
            {
                myList = new ObservableCollection<RailWay>(DataProvider.Ins.DB.RailWays.Where(a => a.OwnedCompanyId == code));

                staionList = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);
            }
            else
            {
                myList = new ObservableCollection<RailWay>(DataProvider.Ins.DB.RailWays);

                staionList = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);
            }



        }
    }
}
