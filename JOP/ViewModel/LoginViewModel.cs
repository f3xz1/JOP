using GalaSoft.MvvmLight.Command;
using JOP.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JOP.ViewModel
{
    class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User user { get; set; }
        public Visibility Wrong_label_visable { get; set; } = Visibility.Hidden;
        public RelayCommand LoginCommand
        {

            get => new(

                async () =>
                {
                    using (DBContext appContext = new DBContext())
                    {
                        user.login = Login;
                        user.password = Password;

                        User getuser = appContext.Users.First(a => a.login == this.user.login && a.password == this.user.password);
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
                    () =>
                    {
                        //RegWindow reg = new();
                        //reg.ShowDialog();
                        //user = reg.user;
                        //if (user != null)
                        //{
                        //    var res = user.create_user_async();
                        //    this.Login = user.login;
                        //    this.Password = user.password;
                        //}
                        CartWindow cartWindow = new();
                        //cartWindow.MyList.Items.Add("qwe","123");
                        cartWindow.Show();
                    }
                    );
        }
    }
}