using GalaSoft.MvvmLight.Command;
using JOP.Model;
using JOP.Services;
using JOP.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JOP.ViewModel
{
    class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        static public User user { get; set; }
        public Message userMessage { get; set; } = new();
        public Visibility Wrong_label_visable { get; set; } = Visibility.Hidden;
        public RelayCommand LoginCommand
        {
            get => new(
                () =>
                {
                    user = new();
                    using (ShopContext appContext = new ShopContext())
                    {
                        user.Login = Login;
                        user.Password = Password;

                        user = appContext.Users.First(a => a.Login == user.Login && a.Password == user.Password);
                    }
                    MessageBox.Show(user.Login+user.Password);
                    if (user != null && !user.IsAdmin)
                    {
                        SHOP_list shop_List = new();
                        shop_List.DataContext = new SHOP_list_ViewModel();
                        Application.Current.Windows[0].Close();
                        shop_List.Show();
                    }
                    else if (user.IsAdmin)
                    {
                        Application.Current.Windows[0].Close();
                        Process.Start("C:\\Users\\f3xz1\\source\\repos\\JOP\\SHOP_admin\\bin\\Debug\\net6.0-windows\\SHOP_admin.exe"); // problem!!!
                    }
                    else
                    {
                        Wrong_label_visable = Visibility.Visible;
                    }
                }
                );
        }
        public RelayCommand RegCommand {
            get =>
                new(
                    async () =>
                    {
                        RegWindow reg = new();
                        reg.DataContext = new RegisterViewModel(userMessage);
                        reg.ShowDialog();
                        user = userMessage.user;
                        if (user != null)
                        {
                            try
                            {
                                MessageBox.Show(user.Id.ToString() + user.Login + user.Surname);
                                using (ShopContext db = new())
                                {
                                    db.Users.Add(user);
                                    db.SaveChanges();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("CreateUserThrow");
                                throw;
                            }
                            //user.create_user();
                            this.Login = user.Login;
                            this.Password = user.Password;
                        }
                    }
                    );
        }
    }
}