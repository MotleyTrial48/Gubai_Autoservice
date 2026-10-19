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

namespace Gubai_Autoservice
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            ComboType.SelectedIndex = 0;
            UpdateServices();
        }

        private void UpdateServices()
        {
            if (!IsInitialized) return;

            var currentServices = Губайдуллин_АвтосервимсEntities.GetContext().Service.ToList();

            switch (ComboType.SelectedIndex)
            {
                case 1: currentServices = currentServices.Where(p => (p.Discount ?? 0) >= 0 && (p.Discount ?? 0) < 5).ToList(); break;
                case 2: currentServices = currentServices.Where(p => (p.Discount ?? 0) >= 5 && (p.Discount ?? 0) < 15).ToList(); break;
                case 3: currentServices = currentServices.Where(p => (p.Discount ?? 0) >= 15 && (p.Discount ?? 0) < 30).ToList(); break;
                case 4: currentServices = currentServices.Where(p => (p.Discount ?? 0) >= 30 && (p.Discount ?? 0) < 70).ToList(); break;
                case 5: currentServices = currentServices.Where(p => (p.Discount ?? 0) >= 70 && (p.Discount ?? 0) <= 100).ToList(); break;
            }

            string q = TBoxSearch.Text.ToLower();
            currentServices = currentServices.Where(p =>
                p.Title.ToLower().Contains(q) ||
                (p.Description != null && p.Description.ToLower().Contains(q))).ToList();

            if (RButtonUp.IsChecked == true)
                currentServices = currentServices.OrderBy(p => p.Cost).ToList();
            if (RButtonDown.IsChecked == true)
                currentServices = currentServices.OrderByDescending(p => p.Cost).ToList();

            ServiceListView.ItemsSource = currentServices;
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e) => UpdateServices();
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateServices();
        private void RButtonUp_Checked(object sender, RoutedEventArgs e) => UpdateServices();
        private void RButtonDown_Checked(object sender, RoutedEventArgs e) => UpdateServices();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }
    }
}
