using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E_Metro.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand TicketWindowCommand { get; set; }
        public ICommand CompanyWindowCommand { get; set; }
        public ICommand TrafficWindowCommand { get; set; }

        public int code;
        public bool permission;

        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => 
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
               
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                { 
                    p.Show(); 
                }
                else
                {
                    p.Close();
                }
            }
              );
            //load window khi nhấn 1 nút nào đấy 
            TicketWindowCommand = new RelayCommand<object>((p) =>
            {
                code = LoginViewModel.idR;

                if (code == 4 || code == 1)
                {
                    permission = true;
                }
                else
                {
                    permission = false;
                }

                return true;
            }, 
            (p) => 
            {
                if (permission == true)
                {
                    Banve wd = new Banve(); wd.Show();
                    Sold wd1 = new Sold(); wd1.Show(); wd1.Close();
                }
                else
                {
                    MessageBox.Show("You are not authorized !");
                }
                 
            });

            CompanyWindowCommand = new RelayCommand<object>((p) => 
            {
                code = LoginViewModel.idR;

                if (code == 3 || code == 1)
                {
                    permission = true;
                }
                else
                {
                    permission = false;
                }

                return true;
            }, 
            (p) =>
            {
                if (permission == true)
                {
                    CompanyWindow wd = new CompanyWindow(); wd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You are not authorized !");
                } 
            });

            TrafficWindowCommand = new RelayCommand<object>((p) => 
            {
                code = LoginViewModel.idR;

                if (code == 2 || code == 1)
                {
                    permission = true;
                }
                else
                {
                    permission = false;
                }

                return true;
            }, 
            (p) => 
            { 
                if(permission == true)
                {
                    TrafficWindow wd = new TrafficWindow(); wd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You are not authorized !");
                }
            });
        }
        
    }
}
