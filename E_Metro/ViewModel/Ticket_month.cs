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
    class Ticket_month : BaseViewModel
    {
        private ObservableCollection<MonthlyTicket> _MonthList;
        public ObservableCollection<MonthlyTicket> MonthList { get => _MonthList; set { _MonthList = value; OnPropertyChanged(); } }
        // click
        private String _SName;
        public String SName { get => _SName; set { _SName = value; OnPropertyChanged(); } }
        private String _SCm;
        public String SCm { get => _SCm; set { _SCm = value; OnPropertyChanged(); } }
        private String _SPhone;
        public String Sphone { get => _SPhone; set { _SPhone = value; OnPropertyChanged(); } }

        private int? _RId;
        public int? RId { get => _RId; set { _RId = value; OnPropertyChanged(); } }

        private int? _TId;
        public int? TId { get => _TId; set { _TId = value; OnPropertyChanged(); } }

        private String _MEnd;
        public String MEnd { get => _MEnd; set { _MEnd = value; OnPropertyChanged(); } }

        private int? _RGo;
        public int? RGo { get => _RGo; set { _RGo = value; OnPropertyChanged(); } }

        private int? _REnd;
        public int? REnd { get => _REnd; set { _REnd = value; OnPropertyChanged(); } }
        private decimal? _RPrice;
        public decimal? RPrice { get => _RPrice; set { _RPrice = value; OnPropertyChanged(); } }
        private String _MStart;
        public String MStart { get => _MStart; set { _MStart = value; OnPropertyChanged(); } }
        private int? _IdT;
        public int? IdT { get => _IdT; set { _IdT = value; OnPropertyChanged(); } }

        private MonthlyTicket _SelectedItem;
        public MonthlyTicket SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    RId = SelectedItem.RailwayID;
                    SName = SelectedItem.ClientName;
                    SCm = SelectedItem.CLientIdentity;
                    IdT = SelectedItem.IdType;
                    MEnd = SelectedItem.ExpireDate;
                    MStart = SelectedItem.StartDate;
                    Sphone = SelectedItem.Phone;
                    RPrice = SelectedItem.Price;
                }
            }
        }
        public ICommand Savebtn { get; set; }
        public ICommand Updatebtn { get; set; }
        public ICommand Clearbtn { get; set; }

        public Ticket_month()
        {
            _MonthList = new ObservableCollection<MonthlyTicket>(DataProvider.Ins.DB.MonthlyTickets);

            Clearbtn = new RelayCommand<object>((p) =>
            {
                if (SelectedItem != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {               
                DataProvider.Ins.DB.MonthlyTickets.Remove(SelectedItem);
                DataProvider.Ins.DB.SaveChanges();
        
                SoldVM.MonthList.Remove(SelectedItem);
                MonthList.Remove(SelectedItem);
                
            });

            Savebtn = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SCm))
                {
                    return false;

                }
                var displayList = DataProvider.Ins.DB.MonthlyTickets.Where(x => x.CLientIdentity == SCm);

                if (displayList == null || displayList.Count() != 0)

                    return false;
                return true;

            }, (p) =>
            {
                decimal?[] tam = DataProvider.Ins.DB.RailWays.Where(x => x.Id == RId).Select(x => x.Price).ToArray();

                RPrice = tam[0] * 20;               

                var month = new MonthlyTicket
                {
                    ClientName = SName,
                    CLientIdentity = SCm,
                    Phone = Sphone,
                    RailwayID = RId,
                    ExpireDate = MEnd,
                    StartDate = MStart,
                    IdType = (int)2,
                    Price = RPrice

                };

                DataProvider.Ins.DB.MonthlyTickets.Add(month);
                DataProvider.Ins.DB.SaveChanges();
                MonthList.Add(month);

                SoldVM.MonthList.Add(month);

            });
            Updatebtn = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SCm))
                {
                    return false;

                }
                var displayList = DataProvider.Ins.DB.MonthlyTickets.Where(x => x.CLientIdentity == SCm);

                if (displayList == null)

                    return false;
                return true;

            }, (p) =>
            {
                var month = DataProvider.Ins.DB.MonthlyTickets.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();

                month.CLientIdentity = SCm;
                month.ClientName = SName;
                month.Phone = Sphone;
                month.RailwayID = RId;
                month.StartDate = MStart;
                month.ExpireDate = MEnd;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.RailwayID = RId;
            });
        }


    }
}
