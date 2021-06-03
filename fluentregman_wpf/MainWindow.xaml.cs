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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    


    public partial class MainWindow 
    {
        public string TitleWin = "Паша лох";
        public MainWindow()
        {
            InitializeComponent();

            PageLoad(new Page1());
            
        }


        private void PageLoad(Page page)
        {
            MainFrame.Content = page;
            WindowMain.Title = page.Title;
        }

        private void Win_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void ShowBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Hide();
            WindowState = WindowState.Minimized;
        }

        private void CloseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MainWindow mw = new MainWindow();
            Application.Current.Shutdown();
            // mw.Close();
        }


        private void HideBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            min_max_size();

        }

        private void min_max_size()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }


        private void toolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                min_max_size();

        }



    }
}
