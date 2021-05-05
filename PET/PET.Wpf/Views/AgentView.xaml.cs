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
    /// Interaction logic for AgentView.xaml
    /// </summary>
    public partial class AgentView : UserControl
    {
        public AgentView()
        {
            InitializeComponent();
        }

        AgentViewModel viewModel = new AgentViewModel();

        #region Private Methods

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible == true)
            {
                Application.Current.MainWindow.DataContext = viewModel;
            }
        }

        private void buttonCreateAgent_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateAgent(textBoxFirstNameAgents.Text, textBoxLastNameAgents.Text, textBoxAddressAgents.Text, textBoxPhoneNumberAgents.Text, textBoxPhotoAgents.Text);
            dataGridAgents.ItemsSource = viewModel.Agents;
        }

        private void buttonUpdateAgent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAgents.SelectedItem != null)
            {
                viewModel.UpdateAgent(dataGridAgents.SelectedItem, textBoxFirstNameAgents.Text, textBoxLastNameAgents.Text, textBoxAddressAgents.Text, textBoxPhoneNumberAgents.Text,
                    textBoxPhotoAgents.Text);
                dataGridAgents.ItemsSource = viewModel.Agents;
            }
        }

        private void buttonDeleteAgent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAgents.SelectedItem != null)
            {
                viewModel.DeleteAgent(dataGridAgents.SelectedItem);
                dataGridAgents.ItemsSource = viewModel.Agents;
            }
        }

        #endregion
    }
}
