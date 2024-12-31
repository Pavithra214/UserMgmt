using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace UserManagement.UI
{
    /// <summary>
    /// Interaction logic for Country.xaml
    /// </summary>
    public partial class Country : Page
    {
        public Country()
        {
            InitializeComponent();
            string path = Properties.Settings.Default.Rootpath;
            string countrypath = path + "//MasterData" + "//Country.txt";
            if(File.Exists(countrypath))
            {
                string[] val=File.ReadAllLines(countrypath);
                txtcountry.Text = String.Join("\r\n", val);
                
            }
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string path= Properties.Settings.Default.Rootpath;
            string countrypath = path + "//MasterData" + "//Country.txt";
            string[] content = txtcountry.Text.Split("\r\n");
            File.WriteAllLines(countrypath, content);
            MessageBox.Show("The country data is saved successfully");

        }

        private void btnpreview_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
