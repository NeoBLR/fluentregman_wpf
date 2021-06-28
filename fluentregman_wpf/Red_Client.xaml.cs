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
    /// Interaction logic for Red_Client.xaml
    /// </summary>
    public partial class Red_Client : Page 
    {
        public Red_Client()
        {
            InitializeComponent();
        }
        public Red_Client(int mode)
        {
            InitializeComponent();
            mode_switch(mode);
        }
        public void mode_switch(int mode) {
            if (mode == 0)
            {
                edit.Visibility = Visibility.Visible;
                add.Visibility = Visibility.Hidden;
            }
            if (mode == 1)
            {
                edit.Visibility = Visibility.Hidden;
                add.Visibility = Visibility.Visible;

            }
        }
        private void Clear_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Clear_GotFocus;
        }

        public string leDb_string = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=.\\db.mdb";

        private void red_Click_Add(object sender, RoutedEventArgs e)
        {

            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            // OleDbDataAdapter da = new OleDbDataAdapter("select * from client", cn);
            // OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            string[] str = new string[6];

            str[0] = surname.Text;
            str[1] = firstname.Text;
            str[2] = patronymic.Text;
            str[3] = Date_of_Birth.Text; //26.05.2021
            str[4] = passport_ID.Text;
            str[5] = Address.Text;


            OleDbCommand oleDbCommand = new OleDbCommand($"insert into client([surname], [firstname], [patronymic], [Date_of_Birth], [passport_ID], [Address]) values('{str[0]}', '{str[1]}', '{str[2]}', '{str[3]}', '{str[4]}', '{str[5]}')", cn);

            oleDbCommand.ExecuteNonQuery();

            cn.Close();


            // DataSet ds = new DataSet();

            //da.Fill(ds, "Code_Clienta");


            //DatagridXAML.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            //goJob.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;



            MessageBox.Show("Добавленно");




            StaticFP.dbase.remove();
            StaticFP.dbase.conect();

            StaticFP.win_edit.Hide();
            
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void red_Click_Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
