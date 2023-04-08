using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_admin.ViewModel
{
    internal class GetUrlViewModel
    {
        public string Url { get; set; }
        public RelayCommand DoneCommand
        {
            get =>
                new(
                     () =>
                     {
                         Application.Current.Windows[3].Close();
                     }
                    );
        }
    }
}
