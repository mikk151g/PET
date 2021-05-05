using PET.Wpf.ViewModels;
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

namespace PET.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ObservantView.xaml
    /// </summary>
    public partial class ObservantView : UserControl
    {
        public ObservantView()
        {
            InitializeComponent();
        }

        ObservantViewModel viewModel = new ObservantViewModel();

        #region Private Methods

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible == true)
            {
                Application.Current.MainWindow.DataContext = viewModel;
            }
        }

        private void buttonCreateObservant_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateObservant(textBoxFirstNameObservants.Text, textBoxLastNameObservants.Text, textBoxAddressObservants.Text, textBoxPhoneNumberObservants.Text, textBoxPhotoObservants.Text,
                textBoxKeywordsObservants.Text, textBoxNationalityObservants.Text, textBoxCprNumberObservants.Text, Convert.ToDecimal(textBoxHeightObservants.Text), textBoxEyeColorObservants.Text, 
                textBoxHairColorObservants.Text, textBoxSkinColorObservants.Text, textBoxHeadgearObservants.Text, textBoxClothesObservants.Text);
            dataGridObservants.ItemsSource = viewModel.Observants;
        }

        private void buttonUpdateObservant_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridObservants.SelectedItem != null)
            {
                viewModel.UpdateObservant(dataGridObservants.SelectedItem, textBoxFirstNameObservants.Text, textBoxLastNameObservants.Text, textBoxAddressObservants.Text, textBoxPhoneNumberObservants.Text, textBoxPhotoObservants.Text,
                textBoxKeywordsObservants.Text, textBoxNationalityObservants.Text, textBoxCprNumberObservants.Text, Convert.ToDecimal(textBoxHeightObservants.Text), textBoxEyeColorObservants.Text,
                textBoxHairColorObservants.Text, textBoxSkinColorObservants.Text, textBoxHeadgearObservants.Text, textBoxClothesObservants.Text);
                dataGridObservants.ItemsSource = viewModel.Observants;
            }
        }

        private void buttonDeleteObservant_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridObservants.SelectedItem != null)
            {
                viewModel.DeleteObservant(dataGridObservants.SelectedItem);
                dataGridObservants.ItemsSource = viewModel.Observants;
            }
        }

        #endregion
    }
}
