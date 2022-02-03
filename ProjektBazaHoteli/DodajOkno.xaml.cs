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
using System.Data.SqlClient;
using System.Data;

namespace ProjektBazaHoteli
{
    /// <summary>
    /// Logika interakcji dla klasy DodajOkno.xaml
    /// </summary>
    public partial class DodajOkno : Window
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L5NIDGD\SQLEXPRESS;Initial Catalog=db_HotelList;Integrated Security=True");

        public DodajOkno()
        {
            InitializeComponent();
        }

        public bool isValid()
        {
            if (nazwa.Text == string.Empty)
            {
                MessageBox.Show("Nazwa nie moze byc pusta");
                return false;
            }
            if (miasto.Text == string.Empty)
            {
                MessageBox.Show("Miasto nie moze byc pusta");
                return false;
            }
            if (iloscGwiazd.Text == string.Empty)
            {
                MessageBox.Show("Ilosc nie moze byc pusta");
                return false;
            }
            if (adress.Text == string.Empty)
            {
                MessageBox.Show("Adress nie moze byc pusta");
                return false;
            }
            return true;
        }

        public void Clear() 
        {
            nazwa.Clear();
            miasto.Clear();
            iloscGwiazd.Clear();
            adress.Clear();
        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TableHotelList VALUES (@Nazwa, @Miasto, @Ilosc_Gwiazd, @Adress)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Nazwa", nazwa.Text);
                    cmd.Parameters.AddWithValue("@Miasto", miasto.Text);
                    cmd.Parameters.AddWithValue("@Ilosc_Gwiazd", iloscGwiazd.Text);
                    cmd.Parameters.AddWithValue("@Adress", adress.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Complete");
                    Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
