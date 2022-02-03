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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ProjektBazaHoteli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L5NIDGD\SQLEXPRESS;Initial Catalog=db_HotelList;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from TableHotelList", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            data_grid.ItemsSource = dt.DefaultView;
        }

        private void DodajBTN(object sender, RoutedEventArgs e)
        {
            DodajOkno DodajO = new DodajOkno();
            DodajO.Show();
            this.Close();
        }
       
        private void EdytujBTN(object sender, RoutedEventArgs e)
        {
            EdytOkno EdytO = new EdytOkno();
            EdytO.Show();
            this.Close();
        }

        private void UsunBTN(object sender, RoutedEventArgs e)
        {
            DeteteOkno DeleteO = new DeteteOkno();
            DeleteO.Show();
            this.Close();

        }

        private void ZapiszBTN(object sender, RoutedEventArgs e)
        {
            Report RO = new Report();
            RO.Show();
        }
    }
}
