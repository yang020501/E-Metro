﻿using E_Metro.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace E_Metro.ViewModel

{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public static int idR;
        public static int idOCom;
 

        // mọi thứ xử lý sẽ nằm trong này
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {           
            if (p == null)
                return;
            string passEncode = CreateMD5(Base64Encode(Password));
            var accCount = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode ).Count();
            
                                                            
            if (accCount > 0)
            {
                var sss = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode).Select(x => x.IdRole).ToArray();

                idR = int.Parse(sss[0].ToString());
                
                if (idR == 3)
                {
                    var kkk = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode).Select(x => x.CompanyID).ToArray();
                    idOCom = int.Parse(kkk[0].ToString());
                }
                else
                {
                    idOCom = 0;
                }

                IsLogin = true;
                Console.WriteLine("-----------" + idR);
                Console.WriteLine("-----------" + idOCom);
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai thông tin đăng nhập !");
            }
            
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        
    }
}
