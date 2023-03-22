using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOP.ViewModel
{
    class Product_window_ViewModel
    {
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
