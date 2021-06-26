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

using System.Data.OleDb;
using System.Data;

namespace fluentregman_wpf
{
    /// <summary>
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            string CommandText = $"SELECT COUNT(*) FROM Users WHERE Login='{Login.Text}' AND Pass='{Pass.Password}'";//Мы просто получаем кол-во строк результата запроса

            OleDbCommand oleDbCommand = new OleDbCommand(CommandText, cn);


            //oleDbCommand.ExecuteNonQuery();



            MessageBox.Show($"{CommandText}");

            MessageBox.Show($"{oleDbCommand.ExecuteNonQuery().ToString()} {Login.Text} {Pass.Password}");


            cn.Close();

            

            if (false)
            {
                NavigationService.Navigate(new DataBase());

            }

        }

        private void Clear_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Clear_GotFocus;
        }
        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {

        }


        public string leDb_string = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=.\\db.mdb";


        public void conect()
        {
            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from client", cn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "Code_Clienta");


            //DatagridXAML.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
           // goJob.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            cn.Close();

            //MessageBox.Show("connected");
        }

    }
}
