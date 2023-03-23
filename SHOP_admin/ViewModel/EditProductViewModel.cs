using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_admin.ViewModel
{
    internal class EditProductViewModel
    {
        public RelayCommand EditProductCommand
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
