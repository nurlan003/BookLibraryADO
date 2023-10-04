using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class DataAccess
    {

        SqlConnection? coni = null;
        public string? CBookName;
        public string? CBookPrice;
        public string? CBookPages;

        public string? CBookName2;
        public int CBookPrice2;
        public int CBookPages2;

        public string? CBookName3;
        public DataAccess()
        {


            string connectionString = @"Data Source=STHQ0124-07;Initial Catalog=Books;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;";
            coni = new SqlConnection(connectionString);

        }


        public void insertDatabase()
        {

            coni.Open();
            string insertData = $"INSERT INTO Book( DBName, DBPages ,DBPrice) VALUES ('{CBookName}' ,'{CBookPrice}' ,'{CBookPages}')";
            using SqlCommand cmd = new SqlCommand(insertData, coni);
            cmd.ExecuteNonQuery();


        }

        public void ShowDatabase()
        {
            SqlDataReader reader = null;
            try
            {
                coni.Open();
                using SqlCommand command = new SqlCommand("SELECT * FROM book", coni);
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    CBookName2 +=("Name:"+(string?)reader["DBName"] +" "+ "Pages:" + (int)reader["DBPages"]+ " " + "Price:" + (int)reader["DBPrice"]+"                  ");
                  
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                coni.Close();
            }
        }


    }


    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            DataAccess access = new DataAccess();
            access = new DataAccess();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess access = new DataAccess();
            access = new DataAccess();
            access.CBookName = bkName.Text;
            access.CBookPrice = bkPrice.Text;
            access.CBookPages = bkPages.Text;
            access.insertDatabase();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccess accesss = new DataAccess();
            accesss = new DataAccess();
            accesss.ShowDatabase();
            books.Text += accesss.CBookName2;

        }
    }
}

