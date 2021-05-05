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

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible == true)
            {
                Application.Current.MainWindow.DataContext = viewModel;
            }
        }
    }
}
