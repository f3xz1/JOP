using GalaSoft.MvvmLight.Command;
using JOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHOP_admin.ViewModel
{
    class AddAdminViewModel
    {
        public User Users { get; set; }
        public RelayCommand SelectedUserCommand
        {
            get =>
                new(
                      async() =>
                     {
                         using (ShopContext db = new())
                         {
                             if (!Users.IsAdmin)
                             {
                                 db.Users.Where(x => x.Login == Users.Login).First().IsAdmin = true;
                                 MessageBox.Show($"{Users.Login} is admin");
                             }
                             else
                             {
                                 db.Users.Where(x => x.Login == Users.Login).First().IsAdmin = false;
                                 MessageBox.Show($"{Users.Login} is not admin");
                             }
                             db.SaveChanges();
                         }
                     }
                    );
        }
    }
}