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

namespace JOP.ViewModel
{
    class RegisterViewModel
    {

        public string Login { get; set; }
        public string Password_1 { get; set; }
        public string Password_2 { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User User { get; set; }

        public Brush RegButtonColor { get; set; }
        public Brush CancelButtonColor { get; set; }


        public RelayCommand RegUserCommand
        {

            get =>
                new(

                    () =>
                    {
                        if (this.Password_1 != Password_2)
                        {
                            RegButtonColor = Brushes.Red;
                            CancelButtonColor = Brushes.Red;
                            return;
                        }
                        User = new User();
                        User.login = Login;
                        User.name = Name;
                        User.surname = Surname;
                        User.password = this.Password_1;
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