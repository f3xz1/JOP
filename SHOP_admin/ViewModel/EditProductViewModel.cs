using GalaSoft.MvvmLight.Command;
using JOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D.Converters;

namespace SHOP_admin.ViewModel
{
    internal class EditProductViewModel
    {
        public Product SelectedProduct { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public RelayCommand EditProductCommand
        {
            get =>
                new(
                     () =>
                     {
                         using (ShopContext db = new())
                         {
                             var prod = db.Products.Find(SelectedProduct.Id);
                             prod.Name = Name;
                             prod.Quality = int.Parse(Quality);
                             prod.Price = double.Parse(Price);
                             prod.Description = Description;

                             if(!db.Categories.Any(x=>x.Name == Category))
                             {
                                 Category category = new(Category);
                                 db.Categories.Add(category);
                                 db.SaveChanges();
                                 
                             }
                             var categ = db.Categories.Where(x => x.Name == Category).First();
                             prod.Category = categ;
                             prod.CategoryId = categ.Id;
                         }
                     }
                    );
        }
        public RelayCommand CloseCommand
        {
            get =>
                new(
                     () =>
                     {
                         Application.Current.Windows[2].Close();
                     }
                    );
        }
    }
}
