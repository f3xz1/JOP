using GalaSoft.MvvmLight.Command;
using JOP;
using SHOP_admin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
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
        public BitmapImage Image { get; set; }
        public string ImageUrl { get; set; }

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
        public RelayCommand ChangeImageCommand
        {
            get =>
                new(
                     async () =>
                     {
                         GetUrlView getUrlView = new();
                         GetUrlViewModel  getPictureUrlViewModel = new();
                         getUrlView.DataContext = getPictureUrlViewModel;
                         getUrlView.ShowDialog();
                         this.ImageUrl = getPictureUrlViewModel.Url;
                         await LoadImage(ImageUrl);
                         Application.Current.Windows[2].Close();
                     }
                    );
        }

        public async Task LoadImage(string url)
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var image1 = new BitmapImage();
                image1.BeginInit();
                image1.CacheOption = BitmapCacheOption.OnLoad;
                image1.StreamSource = stream;
                image1.EndInit();
                Image = image1;
            }
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
