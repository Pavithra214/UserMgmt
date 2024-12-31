using System.IO;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;


namespace UserManagement.UI
{
    /// <summary>
    /// Interaction logic for City.xaml
    /// </summary>
    public partial class City : Page
    {
        public City()
        {
            InitializeComponent();
            String Rootpath = Properties.Settings.Default.Rootpath;

            //country
            string countrypath = Path.Join(Rootpath, "MasterData", "Country.txt");
            string[] country = File.ReadAllLines(countrypath);
            cmbcountry.ItemsSource = country;
            cmbcountry.SelectedIndex = 0;

            //state 
            //string statepath = Path.Join(Rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");



            //string[] state = File.ReadAllLines(statepath);
            //cmbstate.ItemsSource = state;
            //cmbstate.SelectedIndex = 0;




        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {

            String rootpath = Properties.Settings.Default.Rootpath;
            if (cmbstate.SelectedItem != null)
            {
                string citypath = Path.Join(rootpath, "MasterData", "City", cmbcountry.SelectedItem.ToString(), cmbstate.SelectedItem + ".txt");
                string[] content = txtcity.Text.Split("\r\n");
                File.WriteAllLines(citypath, content);
                MessageBox.Show("The state data is stored successfully");

            }
            else
            {
                MessageBox.Show("Please select the state");
            }

        }

        private void btnpreview_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }



        private void cmbcountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Rootpath = Properties.Settings.Default.Rootpath;


            //country

            string statepath = Path.Join(Rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");
            string[] state = File.ReadAllLines(statepath);

            cmbstate.ItemsSource = state;
         

        }

        private void cmbstate_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            String Rootpath = Properties.Settings.Default.Rootpath;

            string citypath = Path.Join(Rootpath, "MasterData", "city", cmbcountry.SelectedItem.ToString(), cmbstate.SelectedItem + ".txt");
            if(File.Exists(citypath))
            {
                string[] city = File.ReadAllLines(citypath);

                txtcity.Text = String.Join("\r\n", city);
            }
            else
            {
                txtcity.Text = " ";
            }


        }
    }
}
