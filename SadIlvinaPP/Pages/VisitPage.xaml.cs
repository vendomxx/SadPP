using SadIlvinaPP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SadIlvinaPP.Pages;

namespace SadIlvinaPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для VisitPage.xaml
    /// </summary>
    public partial class VisitPage : Page
    {
        Visit visit= new Visit();
        public VisitPage()
        {
            InitializeComponent();
            childrenCB.ItemsSource = MainWindow.DB.Children.ToList();
            Filter();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (visit.IdVisit == 0)
            {
                MainWindow.DB.Visit.Add(visit);
                MainWindow.DB.SaveChanges();
                NavigationService.Navigate(new Pages.VisitPage());
            }
            else
            {

                this.DataContext = visit;
                MainWindow.DB.SaveChanges();
                visit = null;
            }
        }
        public void Filter()
        {
            var visits = (IEnumerable<Visit>)MainWindow.DB.Visit;
            string filterChildren = childrenFilterTB.Text.ToLower();
            if(!String.IsNullOrEmpty(filterChildren))
            {
                visits = visits.Where(x => x.Children.Surname.ToLower().Contains(filterChildren)).ToList();
            }
            visitsLV.ItemsSource = visits.ToList();
        }
        private void childrenFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
