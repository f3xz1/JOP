using GalaSoft.MvvmLight.Command;
using JOP.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JOP.ViewModel
{
    public class SHOP_list_ViewModel:INotifyPropertyChanged
    {
        public bool EditProductsMod { get; set; } = false;
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set;}
        //public ObservableCollection<Product> Products { get; set;}

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
                            MessageBox.Show(SelectedCategory.Id.ToString());
                            Products =db.Products.Where(x=>x.CategoryId == SelectedCategory.Id && x.Quality>0).ToList();
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
