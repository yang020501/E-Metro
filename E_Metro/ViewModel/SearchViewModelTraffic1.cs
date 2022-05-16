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
    class SearchViewModelTraffic1 : BaseViewModel
    {
        public ICommand EditCommand { get; set; }
        private ObservableCollection<Company> _myList1;
        public ObservableCollection<Company> myList1 { get => _myList1; set { _myList1 = value; OnPropertyChanged(); } }
        private Company _Selected;
        public Company Selected { get => _Selected; set 
            {
                _Selected = value;
                OnPropertyChanged();
                if (Selected != null)
                {
                    SName = Selected.DisplayName;
                    SWeb = Selected.Website;
                    SAddress = Selected.Address;
                    SPhone = Selected.Phone;
                }
            } }

        private String _SName;
        public String SName { get => _SName; set { _SName = value; OnPropertyChanged(); } }

        private String _SWeb;
        public String SWeb { get => _SWeb; set { _SWeb = value; OnPropertyChanged(); } }

        private String _SAddress;
        public String SAddress { get => _SAddress; set { _SAddress = value; OnPropertyChanged(); } }

        private String _SPhone;
        public String SPhone { get => _SPhone; set { _SPhone = value; OnPropertyChanged(); } }


        public SearchViewModelTraffic1()
        {
            myList1 = new ObservableCollection<Company>(DataProvider.Ins.DB.Companies);

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (Selected == null)
                    return false;

                var displaylist = DataProvider.Ins.DB.Companies.Where(x => x.Id == Selected.Id);
                if (displaylist != null || displaylist.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var change = DataProvider.Ins.DB.Companies.Where(x => x.Id == Selected.Id).SingleOrDefault();
                change.DisplayName = SName;
                change.Website = SWeb;
                change.Address = SAddress;
                change.Phone = SPhone;
                DataProvider.Ins.DB.SaveChanges();


            });
        }
    }
}
