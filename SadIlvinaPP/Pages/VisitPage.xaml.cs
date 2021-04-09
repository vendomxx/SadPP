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
        Visit visit;
        public VisitPage()
        {
            InitializeComponent();
            childrenCB.ItemsSource = MainWindow.DB.Children.ToList();
            this.DataContext = visit;
            Filter();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
           visit = visitsLV.SelectedItem as Visit;
            if (visit == null)
            {
                var x = this.DataContext as Visit;
                MainWindow.DB.Visit.Add(x);
                NavigationService.Navigate(new Pages.VisitPage());
            }
            MainWindow.DB.SaveChanges();
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

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedVisit = visitsLV.SelectedItem as Visit;
            if (selectedVisit != null)
                this.DataContext = selectedVisit;
            else MessageBox.Show("Выберите элемент для редактирования!");
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedVisit = visitsLV.SelectedItem as Visit;
            if(selectedVisit!=null)
            {
                MainWindow.DB.Visit.Remove(selectedVisit);
                MainWindow.DB.SaveChanges();
            }
          else MessageBox.Show("Выберите элемент для редактирования!");
        }
    }
}
