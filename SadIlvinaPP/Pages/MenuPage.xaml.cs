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

namespace SadIlvinaPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void childrenBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ChildrenPage());
        }

        private void parentBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ParentPage());
        }

        private void groupBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.GroupPage());
        }

        private void visitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.VisitPage());
        }
    }
}
