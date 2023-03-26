using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

using JOP;
using JOP.View;
using SHOP_admin.Model;

namespace SHOP_admin.ViewModel
{
    internal partial class MainMenuViewModel
    {

        public RelayCommand AddProductCommand
        {

            get =>
                new(
                     () =>
                    {
                        Product_window product_Window = new();
                        product_Window.DataContext = new AddProductViewModel();
                        product_Window.ShowDialog();

                    }
                    );
        }
        public RelayCommand EditProductCommand
        {
            get =>
                new(
                     () =>
                     {
                         SHOP_list SHOP_Window = new();

                         SHOP_Window.DataContext = new EditProductViewModel(); //Change vm

                         SHOP_Window.ShowDialog();

                     }
                    );
        }
        public RelayCommand AddAdminCommand
        {
            get =>
                new(
                     () =>
                     {
                         UsersListWindow usersListWindow = new();
                         usersListWindow.DataContext = new AddAdminViewModel();
                         usersListWindow.ShowDialog();
                     }
                    );
        }
    }
}
