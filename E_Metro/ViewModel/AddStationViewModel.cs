using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class AddStationViewModel : BaseViewModel
    {
        private string _DisplayName;
        public string DisplayName
        {
            get => _DisplayName; set
            {
                _DisplayName = value;
                OnPropertyChanged();
            }
        }

        private string _Address;
        public string Address
        {
            get => _Address; set
            {
                _Address = value;
                OnPropertyChanged();
            }
        }

        private string _Status;
        public string Status
        {
            get => _Status; set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }
        public System.Windows.Input.ICommand AddCommand { get; set; }
        public AddStationViewModel()
        {
            List<int> list = Model.DataProvider.Ins.DB.Stations.Select(x => x.Id).ToList();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;

                var displayList = DataProvider.Ins.DB.Stations.Where(x => x.DisplayName == DisplayName);

                if (displayList == null || displayList.Count() == 0)
                    return true;
                else return false;
            }, (p) =>
            {
                var object2 = new Station { DisplayName = DisplayName, Address = Address, Status = Status };
                DataProvider.Ins.DB.Stations.Add(object2);
                DataProvider.Ins.DB.SaveChanges();

                TrafficViewModel.myList2.Add(object2);
            });

        }
    }

}
