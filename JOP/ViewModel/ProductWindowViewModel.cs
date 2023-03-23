using GalaSoft.MvvmLight.Command;
using SHOP_admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JOP.ViewModel
{
    public class ProductWindowViewModel
    {
        public int mod { get; set; } = (int)ProductWindowMod.Sell;
        User User { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        

        public RelayCommand DoneCommand
        {
            get =>
                new(
                    () =>
                    {
                        
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
