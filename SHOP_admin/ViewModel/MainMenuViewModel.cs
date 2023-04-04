using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

using JOP;
using JOP.View;
using JOP.ViewModel;
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
                        Product_window product_Window = new Product_window();
                        product_Window.DataContext = new AddProductViewModel();
                        product_Window.Show();
                    }
                    );
        }
        public RelayCommand EditProductCommand
        {
            get =>
                new(
                     () =>
                     {
                         SHOP_list Shop_Window = new();
                         var vm = new SHOP_list_ViewModel();
                         vm.EditProductsMod = true;
                         Shop_Window.DataContext =
                         Shop_Window.ShowDialog();
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
