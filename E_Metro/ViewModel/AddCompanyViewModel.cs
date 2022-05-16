using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class AddCompanyViewModel : BaseViewModel
    {
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set
            {
                _DisplayName = value;
                OnPropertyChanged();
            } }

        private int? _IdAStation;
        public int? IdAStation { get => _IdAStation; set { _IdAStation = value; OnPropertyChanged(); } }

        private int? _IdLStation;
        public int? IdLStation { get => _IdLStation; set { _IdLStation = value; OnPropertyChanged(); } }

        private decimal? _SPrice;
        public decimal? SPrice { get => _SPrice; set { _SPrice = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _boxList;
        public ObservableCollection<int> boxList { get => _boxList; set { _boxList = value; OnPropertyChanged(); } }

        public int code = LoginViewModel.idOCom;

        public System.Windows.Input.ICommand AddCommand { get; set; }
        public AddCompanyViewModel()
        {
            List<int> list = DataProvider.Ins.DB.Stations.Select(x => x.Id).ToList();
            boxList = new ObservableCollection<int>(list);

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
                var objects = new RailWay() { DisplayName = DisplayName, DepartureID = IdLStation, DestinationID = IdAStation, Price = SPrice, OwnedCompanyId = code };
                DataProvider.Ins.DB.RailWays.Add(objects);
                DataProvider.Ins.DB.SaveChanges();

                CompanyViewModel.myList.Add(objects);
            });
            
        }
    } }
