﻿using System;
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
    /// Interaction logic for DataBase.xaml
    /// </summary>
    public partial class DataBase : Page
    {
        public DataBase()
        {
            InitializeComponent();
        }
        public class Writedb
        {
            public string Code_Clienta { get; set; }
            public string surname { get; set; }
            public string firstname { get; set; }
            public string patronymic { get; set; }
            public string Date_of_Birth { get; set; }
            public string passport_ID { get; set; }
            public string Address { get; set; }


            public Writedb()
            {

            }

            public Writedb(string Code_Clienta, string surname, string firstname, string patronymic, string Date_of_Birth,
                string passport_ID, string Address)
            {
                this.Code_Clienta = Code_Clienta;
                this.surname = surname;
                this.firstname = firstname;
                this.patronymic = patronymic;
                this.Date_of_Birth = Date_of_Birth;
                this.passport_ID = passport_ID;
                this.Address = Address;
            }
        }

        //public int selected_id;
        private void goJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                selected_id_client = Convert.ToInt32(row_selected["Code_Clienta"].ToString());



                StaticFP.pClientEdit.surname.Text = row_selected["surname"].ToString();
                StaticFP.pClientEdit.firstname.Text = row_selected["firstname"].ToString();
                StaticFP.pClientEdit.patronymic.Text = row_selected["patronymic"].ToString();
                StaticFP.pClientEdit.DatePickerB.Text = row_selected["Date_of_Birth"].ToString();
                StaticFP.pClientEdit.passport_ID.Text = row_selected["passport_ID"].ToString();
                StaticFP.pClientEdit.Address.Text = row_selected["Address"].ToString();
            }



        }

        public string leDb_string = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=.\\db.mdb";

        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Find_GotFocus;
        }


        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "ПОИСК")
            {
                Button_Click_5(sender, e);
            }
        }

       

        private void Button_Add_Client(object sender, RoutedEventArgs e)
        {

            // win.Content = pClient;
            // win.Show();



            StaticFP.win_edit.PageLoad(StaticFP.pClientAdd);
            StaticFP.win_edit.Show();

            /*
            add_client add_Client = new add_client();
            add_Client.ShowDialog(); */
        }


        private void Button_Edit_Client(object sender, RoutedEventArgs e)
        {

            StaticFP.win_edit.PageLoad(StaticFP.pClientEdit);
            StaticFP.win_edit.Show();

            

            //goJob.SelectedItem



            //MessageBox.Show($"id {clid} name {clname}");

            //ProgramStatic.cclient.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            remove();
            conect();
        }


        public int selected_id_client;
        public int selected_id_user;

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            // OleDbDataAdapter da = new OleDbDataAdapter("select * from client", cn);
            // OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            string[] str = new string[6];

            OleDbCommand oleDbCommand = new OleDbCommand($"DELETE FROM client WHERE Code_Clienta = {selected_id_client}", cn);

            oleDbCommand.ExecuteNonQuery();

            cn.Close();

            remove();
            conect();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            remove();

            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM client WHERE surname LIKE '{Find.Text}%' OR firstname LIKE '{Find.Text}%' ", cn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "Code_Clienta");


            //DatagridXAML.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            goJob.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            cn.Close();
        }

        public void remove()
        {
            goJob.ItemsSource = null;
            //MessageBox.Show("removed");

        }

        public void conect()
        {
            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from client", cn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "Code_Clienta");


            //DatagridXAML.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            goJob.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            cn.Close();

            //MessageBox.Show("connected");
        }

        public void conect2()
        {
            OleDbConnection cn = new OleDbConnection(leDb_string);

            cn.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from Users", cn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "Cod_User");


            //DatagridXAML.ItemsSource = ds.Tables["Code_Clienta"].DefaultView;
            goJob2.ItemsSource = ds.Tables["Cod_User"].DefaultView;
            cn.Close();

            //MessageBox.Show("connected");
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conect();
            conect2();
        }

        private void goJob2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                selected_id_user = Convert.ToInt32(row_selected["Cod_User"].ToString());

         

            }

        }



        private void Button_Add_User(object sender, RoutedEventArgs e)
        {
            MainWindow Add = new MainWindow(new Add_User(), 1);
          
            Add.Show();
        }
    }
}
