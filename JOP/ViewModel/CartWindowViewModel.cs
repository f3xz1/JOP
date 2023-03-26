using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace JOP.ViewModel
{
    internal class CartWindowViewModel
    {
        User User { get; set; }

        public List<Product> CartProducts { get; set; }

        public RelayCommand FinishShopingCommand
        {
            get =>
                new(
                    () =>
                    {
                        if (MessageBox.Show("Finish shoping?", "Finish?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                            return;


                        List<Product> FinalProductsList;
                        FinalProductsList = CartProducts;// selected products

                        using (ShopContext db = new())
                        {
                           var UsersCart = db.TakenProducts.Where(p => p.Customer == User && FinalProductsList.Contains(p.Product)); 
                            db.TakenProducts.RemoveRange(UsersCart);
                            db.SaveChangesAsync();

                            var OtherProducts = db.TakenProducts.Where(x=>x.Customer == User).Select(Product => Product.Product).ToList();

                            for (int i = 0; i < OtherProducts.Count; i++)// add to exsisting products quality or add new product
                            {
                                if (db.Products.Contains(OtherProducts[i]))
                                {
                                    db.Products.Where(x => x.Id == OtherProducts[i].Id).First().Quality += OtherProducts[i].Quality;
                                }
                                else
                                {
                                    db.Products.Add(OtherProducts[i]);
                                }
                            }
                            db.SaveChangesAsync();
                        }
                    }
                    );
        }

        public void SendCheck()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com") // reg shop gmail
            {
                Port = 587,
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true,
            };
            StringBuilder Check = new();
            Check.Append("The check of the shop made by github.com/f3xz1\n\n" +
                "**************************************");
            for (int i = 0; i < CartProducts.Count; i++)
            {
                Check.Append($" {CartProducts[i].Quality} of {CartProducts[i].Name}: {CartProducts[i].Quality * CartProducts[i].Quality}\n");
            }
            Check.Append($"\n Data: {System.DateTime.Now.ToLongDateString()}");

            smtpClient.SendMailAsync("email", "recipient", "subject", "body");
        }

        public RelayCommand CloseCommand
        {
            get =>
                new(
                    () =>
                    {

                    }
                    );
        }


    }
}
