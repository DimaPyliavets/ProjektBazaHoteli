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
    /// Logika interakcji dla klasy DeteteOkno.xaml
    /// </summary>
    public partial class DeteteOkno : Window
    {

        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L5NIDGD\SQLEXPRESS;Initial Catalog=db_HotelList;Integrated Security=True");

        public DeteteOkno()
        {
            InitializeComponent();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from TableHotelList where ID = " +nazwa.Text+ " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not deleted");
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
    }
}
