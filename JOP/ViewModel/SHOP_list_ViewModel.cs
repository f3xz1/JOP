using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOP.ViewModel
{
    class SHOP_list_ViewModel
    {

        public bool EditProductsMod { get; set; } = false;
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public Category SelectedCategory { get; set; }
            
        public User User { get; set; }

        public SHOP_list_ViewModel()
        {
            using (ShopContext dB = new())
            {
                Categories = dB.Categories.ToList();
            }
        }
        public RelayCommand SelectedCategoryCommand
        {
            get =>
                new(
                    async () =>
                    {
                        using (ShopContext db = new())
                        {
                            Products = db.Products.Where(x=>x.CategoryId == SelectedCategory.Id).ToList();
                        }
                    }
                    );
        }

        public RelayCommand SelectedProductCommand
        {
            get =>
                new(
                     () =>
                    {
                        using (ShopContext dB = new())
                        {

                        }
                    }
                    );
        }
    }
}
