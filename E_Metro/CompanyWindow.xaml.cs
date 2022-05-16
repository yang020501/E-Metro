using E_Metro.ViewModel;
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
    /// Interaction logic for CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        public int code;

        public CompanyWindow()
        {
            InitializeComponent();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            code = LoginViewModel.idR;
            if (code == 1)
            {
                MessageBox.Show("You are not authorized !");
            }
            else
            {
                SearchWindow wd = new SearchWindow();
                wd.ShowDialog();
            }
        }

       
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            code = LoginViewModel.idR;
            if(code == 1)
            {
                MessageBox.Show("You are not authorized !");
            }
            else
            {
                AddWindow wd = new AddWindow();
                wd.ShowDialog();
            }
            
        }

        
    }
}
