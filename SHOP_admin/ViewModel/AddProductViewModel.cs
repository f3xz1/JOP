using GalaSoft.MvvmLight.Command;
using JOP;
using JOP.View;
using Microsoft.EntityFrameworkCore;
using SHOP_admin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SHOP_admin.ViewModel
{
    internal class AddProductViewModel
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public BitmapImage Image { get; set; }

        public bool NameTextboxEnabled { get; set; } = true;
        public bool QualityTextboxEnabled { get; set; } = true;
        public bool PriceTextboxEnabled { get; set; } = true;
        public bool CategoryTextboxEnabled { get; set; } = true;
        public bool DescriptionTextboxEnabled { get; set; } = true;

        public RelayCommand DoneCommand
        {
            get =>
                new(
                     async () =>
                     {
                         Product product = new();
                         Category category = new(Category);
                         using (ShopContext db = new())
                         {
                             if (!db.Categories.Any(x => x.Name.ToLower().Contains(Category.ToLower())))
                             {
                                 product.Category = category;
                             }
                             else
                                 product.CategoryId = db.Categories.Where(x => x.Name == Category).First().Id; // null excpn
                         }

                         product.Name = Name;
                         product.Quality = int.Parse(Quality);
                         product.Price = double.Parse(Quality);
                         product.Description = Description;
                         product.Image = ImageUrl;
                         try
                         {
                             using (ShopContext db = new())
                             {
                                 if (db.Products.Any(x => x.Name == (Name.ToLower())))
                                 {
                                     db.Products.Where(x => x.Name == (Name.ToLower())).First().Quality += int.Parse(Quality);
                                     await db.SaveChangesAsync();
                                 }
                                 else
                                 {
                                     db.Products.Add(product);
                                     MessageBox.Show($"{product.Id} {product.Name} {product.Category.Name}");
                                     await db.SaveChangesAsync(); // identity_insert off exception
                                 }
                             }
                         }
                         catch (Exception)
                         {

                             throw;
                         }
                         
                         Application.Current.Windows[2].Close();
                     }
                    );
        }

        public RelayCommand GetImageUrlCommand
        {
            get =>
                 new(
                    async () =>
                     {
                         try
                         {
                             GetUrlView getUrlView = new();
                             GetUrlViewModel getUrl = new();
                             getUrlView.DataContext = getUrl;
                             getUrlView.ShowDialog();
                             this.ImageUrl = getUrl.Url;
                             await LoadImage(ImageUrl);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Can not load Image");
                         }
                     }
                    );
        }
        public async Task LoadImage(string url) // scnd in proj
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
                         Application.Current.Windows[2].Close(); // rechack
                     }
                    );
        }
    }
}
