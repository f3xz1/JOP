using JOP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JOP.View
{
    /// <summary>
    /// Логика взаимодействия для Product_window.xaml
    /// </summary>
    public partial class Product_window : Window
    {
        public Product_window()
        {
            InitializeComponent();
            DataContext = new ProductWindowViewModel();
        }
    }
}
