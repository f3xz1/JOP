using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOP.ViewModel
{
    class SHOP_list_ViewModel
    {

        public bool EditProductsMod { get; set; } = false;
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public Category SelectedCategory { get; set; }
            
        public User User { get; set; }

        public SHOP_list_ViewModel()
        {
            using (DBContext dB = new())
            {
                //Categories = dB.Category;
            }
        }
        public RelayCommand SelectedCategoryCommand
        {
            get =>
                new(
                    async () =>
                    {
                        using (DBContext dB = new())
                        {
                            //Products = dB.Product.Where(x => x.Category.Id = SelectedCategory.Id);
                        }
                    }
                    );
        }

        public RelayCommand SelectedProductCommand
        {
            get =>
                new(
                    async () =>
                    {
                        using (DBContext dB = new())
                        {

                        }
                    }
                    );
        }
    }
}
