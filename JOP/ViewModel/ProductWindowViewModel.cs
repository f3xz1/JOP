using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JOP.ViewModel
{
    
    public class ProductWindowViewModel
    {
        public Product SelectedProduct { get; set; } 
        public int mod { get; set; } = (int)ProductWindowMod.Sell;
        User User { get; set; } = LoginViewModel.user;
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }



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
                        //Application.Current.Windows[---].Close();
                    }
                    );
        }
    }
}
