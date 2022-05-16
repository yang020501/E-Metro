using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Metro.ViewModel
{
    class SoldVM : BaseViewModel
    {

        public static ObservableCollection<TicketSold> DayList { get; set; }

       
        public static ObservableCollection<MonthlyTicket> MonthList { get; set;}

        public SoldVM()
        {
            DayList = new ObservableCollection<TicketSold>(DataProvider.Ins.DB.TicketSolds);
            MonthList = new ObservableCollection<MonthlyTicket>(DataProvider.Ins.DB.MonthlyTickets);
            OnPropertyChanged("DayList");
            OnPropertyChanged("MonthList");

        }
    }
}
