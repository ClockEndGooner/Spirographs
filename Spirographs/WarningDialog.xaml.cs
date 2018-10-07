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
using System.Windows.Shapes;

namespace Spirographs
{
    /// <summary>
    /// Interaction logic for WarningDialog.xaml
    /// </summary>
    public partial class WarningDialog : Window
    {
        public WarningDialog()
        {
            InitializeComponent();
        }

        private void OnDrawButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
