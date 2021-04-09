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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SadIlvinaPP.Model;

namespace SadIlvinaPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SadIlvinaDBEntities DB = new SadIlvinaDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new Pages.MenuPage());
        }

        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.MenuPage());
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
