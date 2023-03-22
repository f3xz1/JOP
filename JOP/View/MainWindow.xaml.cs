using JOP.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            RegWindow reg = new();
            reg.ShowDialog();
            user = reg.user;
            if (user != null)
            {
                var res = user.create_user_async();
                this.Login_textbox.Text = user.login;
                this.Password_textbox.Password = user.password;
            }
        }

        private void Log_Button_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext appContext = new DBContext())
            {
                User getuser = appContext.Users.First(a => a.login == this.user.login && a.password == this.user.password);
                if (getuser != null && !getuser.IsAdmin)
                {
                    //main prog open
                    //Shop_List shop_List = new();
                    //this.Close();
                    //shop_List.Show();3
                }
                else if (getuser.IsAdmin)
                {
                    this.Close();
                    Process.Start("SHOP\\SHOP_admin\\bin\\Debug\\net6.0-windows\\SHOP_admin.exe");
                }
                else
                {
                    this.wrong_info.Visibility = Visibility.Visible;
                }
            }
        }

        private void Password_textbox_GotFocus(object sender, RoutedEventArgs e) // delete or finish
        {
            this.Background = Brushes.AliceBlue;
        }
    }
}
