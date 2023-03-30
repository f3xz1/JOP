using GalaSoft.MvvmLight.Command;
using JOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using JOP.Services;
using System.Security;
using System.ComponentModel;
using JOP.Model;

namespace JOP.ViewModel
{
    public class RegisterViewModel
    {

        public Message userMessage { get; set; }
        public string? Login { get; set; }
        public string? Password_1 { get; set; }
        public string? Password_2
        {
            get; set;
        }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public Brush RegButtonColor { get; set; }
        public Brush CancelButtonColor { get; set; }
        public RegisterViewModel(Message userMessage)
        {
            this.userMessage = userMessage;
            RegButtonColor = Brushes.White;
            CancelButtonColor = Brushes.White;
        }
        public RelayCommand RegUserCommand
        {
            get =>
                new(
                    () =>
                    {
                        using (ShopContext db = new())
                        {
                            if (db.Users.Any((x => x.Login == Login)))
                            {
                                RegButtonColor = Brushes.Red;
                                CancelButtonColor = Brushes.Red; // fix
                                return;
                            }
                        }
                        if (this.Password_1 != Password_2)
                        {
                            RegButtonColor = Brushes.Red;
                            CancelButtonColor = Brushes.Red;
                            return;
                        }

                        User user = new User();
                        user.Login = Login;
                        user.Name = Name;
                        user.Surname = Surname;
                        user.Password = this.Password_1.ToString();
                        user.Email = this.Email;
                        MessageBox.Show($"{Login} {Name} {Surname} {Password_1}");
                        this.userMessage.user = user;
                        Application.Current.Windows[1].Close();
                    }
                    );
        }
        public RelayCommand CancelCommand
        {
            get =>
                new(
                    () =>
                    {
                        Application.Current.Windows[1].Close();
                    }
                    );
        }
    }
}