using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektBazaHoteli
{
    /// <summary>
    /// Logika interakcji dla klasy EdytOkno.xaml
    /// </summary>
    public partial class EdytOkno : Window
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L5NIDGD\SQLEXPRESS;Initial Catalog=db_HotelList;Integrated Security=True");


        public EdytOkno()
        {
            InitializeComponent();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update TableHotelList set Nazwa = '"+ nazwa.Text+"', Miasto = '"+miasto.Text+ "' , Ilosc_Gwiazd = '" + iloscGwiazd.Text + "' , Adress = '" + adress.Text + "' WHERE ID = '"+id.Text+"' ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edited");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
            }
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TableHotelList WHERE ID= " +id.Text+ " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("ID Exist");
                nazwa.IsEnabled = true;
                miasto.IsEnabled = true;
                iloscGwiazd.IsEnabled = true;
                adress.IsEnabled = true;
                id.IsEnabled = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally    
            {
                con.Close();
            }


        }
    }
}
