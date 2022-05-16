using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class AddCompanyTrueViewModel : BaseViewModel
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

        private string _Website;
        public string Website
        {
            get => _Website; set
            {
                _Website = value;
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

        private string _Phone;
        public string Phone
        {
            get => _Phone; set
            {
                _Phone = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Input.ICommand AddCommand { get; set; }
        public AddCompanyTrueViewModel()
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
                var object1 = new Company { DisplayName = DisplayName, Website = Website, Address = Address, Phone = Phone };
                DataProvider.Ins.DB.Companies.Add(object1);
                DataProvider.Ins.DB.SaveChanges();

                TrafficViewModel.myList1.Add(object1);
            });

        }
    }
}


    

