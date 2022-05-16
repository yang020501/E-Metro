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
    class SearchViewModelCompany : BaseViewModel
    {
        public ICommand EditCommand { get; set; }

        private ObservableCollection<RailWay> _myList;
        public ObservableCollection<RailWay> myList { get => _myList; set { _myList = value; OnPropertyChanged(); } }

        private ObservableCollection<Station> _staionList;
        public ObservableCollection<Station> staionList { get => _staionList; set { _staionList = value; OnPropertyChanged(); } }
      
        private RailWay _Selected;
        public RailWay Selected { get => _Selected; 
            set
            {
                _Selected = value; 
                OnPropertyChanged(); 
                if (Selected != null)
                {
                    SName = Selected.DisplayName;
                    IdAStation = Selected.DestinationID;
                    IdLStation = Selected.DepartureID;
                    SPrice = Selected.Price;
                }
            } 
        }

        private String _SName;
        public String SName { get =>  _SName; set {  _SName = value; OnPropertyChanged(); } }

        private int? _IdAStation;
        public int? IdAStation { get => _IdAStation; set { _IdAStation = value; OnPropertyChanged(); } }

        private int? _IdLStation;
        public int? IdLStation { get => _IdLStation; set { _IdLStation = value; OnPropertyChanged(); } }

        private decimal? _SPrice;
        public decimal? SPrice { get => _SPrice; set { _SPrice = value; OnPropertyChanged(); } }
        private ObservableCollection<int> _boxList;
        public ObservableCollection<int> boxList { get => _boxList; set { _boxList = value; OnPropertyChanged(); } }

        public int code = LoginViewModel.idOCom;

        public SearchViewModelCompany()
        {           
            myList = new ObservableCollection<RailWay>(DataProvider.Ins.DB.RailWays.Where(a => a.OwnedCompanyId == code));
            
            staionList = new ObservableCollection<Station>(DataProvider.Ins.DB.Stations);

            List<int> list = DataProvider.Ins.DB.Stations.Select(x => x.Id).ToList();

            boxList = new ObservableCollection<int>(list);

            Console.WriteLine("--------" + code);

            EditCommand = new RelayCommand<object>((p) => 
            {
                if (Selected == null)
                    return false;

                var displaylist = DataProvider.Ins.DB.RailWays.Where(x => x.Id == Selected.Id);
                if (displaylist != null || displaylist.Count() != 0)
                    return true;

                return false;
            }, (p) => 
            {
                var change = DataProvider.Ins.DB.RailWays.Where(x => x.Id == Selected.Id).SingleOrDefault();
                change.DisplayName = SName;
                change.DepartureID = IdLStation;
                change.DestinationID = IdAStation;
                change.Price = SPrice;
                DataProvider.Ins.DB.SaveChanges();


            });
        }

        


    }
}
