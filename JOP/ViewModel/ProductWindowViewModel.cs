using GalaSoft.MvvmLight.Command;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Drawing;
using System.Windows.Media.Imaging;
using System.Net.Http;
using System.Windows.Media;

namespace JOP.ViewModel
{
    
    public class ProductWindowViewModel
    {
        public Product SelectedProduct { get; set; } = new();


        //public int mod
        //{
        //    get { return mod; }
        //    set { mod = value; }
        //} = (int)ProductWindowMod.Sell;

        //public int mod {
        //    get =>{

        //    }; set; } = (int)ProductWindowMod.Sell;
        User User { get; set; } = LoginViewModel.user;
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public BitmapImage Image { get; set; }


        public ProductWindowViewModel()
        {
            Name = SelectedProduct.Name;
            Quality = SelectedProduct.Quality.ToString();
            Price = SelectedProduct.Price.ToString();
            Description = SelectedProduct.Description;

            if (SelectedProduct.Image != null || SelectedProduct.Image != string.Empty)
                LoadImage(SelectedProduct.Image);
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

        public RelayCommand QualityChanged
        {
            get =>
                new(
                    () =>
                    {
                        Price = (SelectedProduct.Price * double.Parse(Quality)).ToString();
                    }
                    );
        }
        public RelayCommand DoneCommand
        {
            get =>
                new(
                    () =>
                    {
                        using (ShopContext db = new())
                        {
                            var item = db.Products.Find(SelectedProduct.Id);
                            if (item.Quality < int.Parse(Quality))
                            {
                                MessageBox.Show("Not enough products");
                                Quality = item.Quality.ToString();
                            }
                            item.Quality-= int.Parse(Quality);

                            TakenProduct takenProduct = new();
                            takenProduct.ProductId = SelectedProduct.Id;
                            takenProduct.Product = SelectedProduct;
                            takenProduct.CustomerId = User.Id;
                            takenProduct.Customer = User;
                            db.TakenProducts.Add(takenProduct);
                            db.SaveChanges();
                        }
                        //Application.Current.Windows[---].Close();
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
