using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                    );
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
