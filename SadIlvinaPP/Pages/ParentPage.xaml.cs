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
    /// Логика взаимодействия для ParentPage.xaml
    /// </summary>
    public partial class ParentPage : Page
    {
        public ParentPage()
        {
            InitializeComponent();
            Filter();
        }
        public void Filter()
        {
            var parents = (IEnumerable<Parent>)MainWindow.DB.Parent;
            string filterParent = parentFilterTB.Text.ToLower();
            if (!String.IsNullOrEmpty(filterParent))
            {
                parents = parents.Where(x => x.Surname.ToLower().Contains(filterParent)).ToList();
            }
            parentsLV.ItemsSource = parents.ToList();
        }
       
        private void parentFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
