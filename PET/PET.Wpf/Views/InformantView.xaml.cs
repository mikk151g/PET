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
    /// Interaction logic for InformantView.xaml
    /// </summary>
    public partial class InformantView : UserControl
    {
        public InformantView()
        {
            InitializeComponent();
        }

        InformantViewModel viewModel = new InformantViewModel();

        #region Private Methods

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible == true)
            {
                Application.Current.MainWindow.DataContext = viewModel;
            }
        }

        private void buttonCreateInformant_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateInformant(textBoxFirstNameInformants.Text, textBoxLastNameInformants.Text, textBoxAddressInformants.Text, textBoxPhoneNumberInformants.Text, textBoxPhotoInformants.Text,
                textBoxKeywordsInformants.Text);
            dataGridInformants.ItemsSource = viewModel.Informants;
        }

        private void buttonUpdateInformant_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridInformants.SelectedItem != null)
            {
                viewModel.UpdateInformant(dataGridInformants.SelectedItem, textBoxFirstNameInformants.Text, textBoxLastNameInformants.Text, textBoxAddressInformants.Text, textBoxPhoneNumberInformants.Text,
                textBoxPhotoInformants.Text, textBoxKeywordsInformants.Text);
                dataGridInformants.ItemsSource = viewModel.Informants;
            }
        }

        private void buttonDeleteInformant_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridInformants.SelectedItem != null)
            {
                viewModel.DeleteInformant(dataGridInformants.SelectedItem);
                dataGridInformants.ItemsSource = viewModel.Informants;
            }
        }

        #endregion
    }
}
