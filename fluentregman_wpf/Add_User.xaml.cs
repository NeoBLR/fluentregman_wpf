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

namespace fluentregman_wpf
{
    /// <summary>
    /// Interaction logic for Add_User.xaml
    /// </summary>
    public partial class Add_User : Page
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void Clear_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Clear_GotFocus;
        }
    }
}
