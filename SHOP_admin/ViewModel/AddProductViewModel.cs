using GalaSoft.MvvmLight.Command;
using JOP;
using JOP.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHOP_admin.ViewModel
{
    internal class AddProductViewModel
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }



        public RelayCommand AddProductCommand
        {
            get =>
                new(
                     async () =>
                     {
                         int CategoryId;
                         using (ShopContext db = new() )
                         {
                             if(db.Categories.Any(x=>x.Name.ToLower() == Category.ToLower()))
                             {
                                 Category category = new(Category);
                                 db.Categories.Add(category);
                                 db.SaveChanges();
                             }
                             CategoryId = db.Categories.Where(x => x.Name == Category).First().Id;
                         }
                         Product product = new(Name,double.Parse(Price), int.Parse(Quality),Description,CategoryId);
                         using (ShopContext db = new())
                         {
                             if(db.Products.Any(x=>x.Name == (Name.ToLower())))
                             {
                                 db.Products.Where(x => x.Name == (Name.ToLower())).First().Quality += int.Parse(Quality);
                                 db.SaveChanges();
                             }
                             else
                             {
                                 db.Products.Add(product);
                                 db.SaveChanges();
                             }
                         }
                         Application.Current.Windows[2].Close();
                     }
                    );
        }

        public RelayCommand CancelCommand
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
