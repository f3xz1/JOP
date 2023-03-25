using GalaSoft.MvvmLight.Command;
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
        public UserService userService { get; set; } = new();
        public Visibility Wrong_label_visable { get; set; } = Visibility.Hidden;
        public RelayCommand LoginCommand
        {
            get => new(
                () =>
                {
                    using (ShopContext appContext = new ShopContext())
                    {
                        user.Login = Login;
                        user.Password = Password;

                        User getuser = appContext.Users.First(a => a.Login == user.Login && a.Password == user.Password);
                        if (getuser != null && !getuser.IsAdmin)
                            {
                                SHOP_list shop_List = new();
                                Application.Current.Windows[0].Close();
                                shop_List.Show();
                            }
                            else if (getuser.IsAdmin)
                            {
                                Application.Current.Windows[0].Close();
                                //Process.Start("SHOP\\SHOP_admin\\bin\\Debug\\net6.0-windows\\SHOP_admin.exe");   Start admin application
                            }
                            else
                            {
                                Wrong_label_visable = Visibility.Visible;
                            }
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
                        reg.DataContext = new RegisterViewModel(userService);
                        reg.ShowDialog();
                        user = userService.user;
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