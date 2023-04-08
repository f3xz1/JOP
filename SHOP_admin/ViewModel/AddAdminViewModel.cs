using GalaSoft.MvvmLight.Command;
using JOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHOP_admin.ViewModel
{
    class AddAdminViewModel
    {
        public User Users { get; set; }
        public List<User> UsersList{get;set;}

        public AddAdminViewModel()
        {
            using (ShopContext db = new())
            {
                UsersList = db.Users.ToList();
            }
        }
        public RelayCommand DoneCommand
        {
            get =>
                new(
                       () =>
                      {
                          Application.Current.Windows[2].Close();
                      }
                    );
        }

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