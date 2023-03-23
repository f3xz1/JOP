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
                         using (DBContext db = new() )
                         {
                             if(db.Category.Select(x=>x.Name == Category) != null)
                             {
                                 Category category = new(Category);
                                 db.Category.Add(category);
                                 db.SaveChanges();
                             }
                             CategoryId = db.Category.Where(x => x.Name == Category).First().Id;
                         }
                         Product product = new(Name,double.Parse(Price), double.Parse(Quality),Description,CategoryId);
                         using (DBContext db = new())
                         {
                             if(db.Product.Where(x=>x.name == (Name.ToLower())).First()!=null)
                             {
                                 db.Product.Where(x => x.name == (Name.ToLower())).First().quality += double.Parse(Quality);
                             db.SaveChanges();
                             }
                             else
                             {
                                 db.Product.Add(product);
                                 db.SaveChanges();
                             }
                         }
                         //Application.Current.Windows[--].Close();
                     }
                    );
        }

        public RelayCommand CancelCommand
        {
            get =>
                new(
                     () =>
                     {
                         //Application.Current.Windows[-------].Close();
                     }
                    );
        }
    }
}
