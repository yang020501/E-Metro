using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Metro.ViewModel
{
    class SearchViewModelTraffic2 : BaseViewModel
    {
        public ICommand EditCommand { get; set; }

        private ObservableCollection<Station> _myList2;
        public ObservableCollection<Station> myList2 { get => _myList2; set { _myList2 = value; OnPropertyChanged(); } }

        private Station _Selected;
        public Station Selected
        {
            get => _Selected; set
            {
                _Selected = value;
                OnPropertyChanged();
                if (Selected != null)
                {
                    SName = Selected.DisplayName;                   
                    SAddress = Selected.Address;
                    SStatus = Selected.Status;
                }
            }
        }

        private String _SName;
        public String SName { get => _SName; set { _SName = value; OnPropertyChanged(); } }
        private String _SAddress;
        public String SAddress { get => _SAddress; set { _SAddress = value; OnPropertyChanged(); } }
        private String _SStatus;
        public String SStatus { get => _SStatus; set { _SStatus = value; OnPropertyChanged(); } }

        public SearchViewModelTraffic2()
        {
            myList2 = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (Selected == null)
                    return false;

                var displaylist = DataProvider.Ins.DB.Stations.Where(x => x.Id == Selected.Id);
                if (displaylist != null || displaylist.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var change = DataProvider.Ins.DB.Stations.Where(x => x.Id == Selected.Id).SingleOrDefault();
                change.DisplayName = SName;               
                change.Address = SAddress;
                change.Status = SStatus;
                DataProvider.Ins.DB.SaveChanges();


            });
        }
    }
}
