using GalaSoft.MvvmLight.Command;
using JOP;
using JOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHOP_admin.ViewModel
{
    internal class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public string Name { get; set; }
        public Category SelectedCategory { get; set; }

        public CategoryViewModel()
        {
            using (ShopContext db = new())
            {
                Categories = db.Categories.ToList();
            }
        }

        public RelayCommand SelectedCategoryCommand
        {
            get =>
                new(
                     () =>
                     {
                         Name = SelectedCategory.Name;
                     }
                    );
        }

        public RelayCommand EditCategoryCommand
        {
            get =>
                new(
                     () =>
                     {
                         // add name chack

                         if(Name == string.Empty)
                         {
                             MessageBox.Show("Select category");
                             return;
                         }
                         using (ShopContext db = new())
                         {
                             db.Categories.Find(SelectedCategory.Id).Name = Name;
                             db.SaveChanges();
                         }
                     }
                    );
        }

        public RelayCommand DeleteCategoryCommand
        {
            get =>
                new(
                     () =>
                     {

                         //check for Products that are joined to Category

                         using(ShopContext db = new())
                         {
                             db.Categories.Remove(SelectedCategory);
                             db.SaveChanges();
                         }
                     }
                    );
        }

    }
}
