using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace E_Metro
{
    /// <summary>
    /// Interaction logic for Banve.xaml
    /// </summary>
    public partial class Banve : Window
    {
        public Banve()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ticket_month wd = new Ticket_month();
            wd.ShowDialog();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sold wd = new Sold();
            wd.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfoStation wd = new InfoStation();
            wd.ShowDialog();
        }
    }
}
