using SadIlvinaPP.Model;
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
    /// Логика взаимодействия для ChildrenPage.xaml
    /// </summary>
    public partial class ChildrenPage : Page
    {
        public ChildrenPage()
        {
            InitializeComponent();
            Filter();
        }
        public void Filter()
        {
            var childrens = (IEnumerable<Children>)MainWindow.DB.Children;
            string filterChildren = childrenFilterTB.Text.ToLower();
            if (!String.IsNullOrEmpty(filterChildren))
            {
                childrens = childrens.Where(x => x.Surname.ToLower().Contains(filterChildren)).ToList();
            }
            childrensLV.ItemsSource = childrens.ToList();
        }

        private void childrenFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
