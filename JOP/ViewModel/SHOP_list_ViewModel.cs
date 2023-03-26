using GalaSoft.MvvmLight.Command;
using JOP.View;
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

        public Product SelectedProduct { get; set; }

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
                            Products = db.Products.Where(x=>x.CategoryId == SelectedCategory.Id && x.Quality>0).ToList();
                        }
                    }
                    );
        }

        public RelayCommand FinishShopingCommand
        {
            get =>
                new(
                     () =>
                    {
                        using (ShopContext db = new())
                        {
                            CartWindow window = new CartWindow();
                            window.ShowDialog();
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
                        Product_window productwindow = new Product_window();
                        var vm = new ProductWindowViewModel();
                        vm.SelectedProduct = SelectedProduct;
                        productwindow.DataContext = vm;
                        productwindow.ShowDialog();
                    }
                    );
        }
    }
}
