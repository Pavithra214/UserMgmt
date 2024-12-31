using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace UserManagement.UI
{
    /// <summary>
    /// Interaction logic for State.xaml
    /// </summary>
    public partial class State : Page
    {
        public State()
        {
            InitializeComponent();
            String Rootpath=Properties.Settings.Default.Rootpath;
            string statepath = Path.Join(Rootpath, "MasterData", "Country.txt");
            string[] country = File.ReadAllLines(statepath);
            cmbcountry.ItemsSource = country;
            cmbcountry.SelectedIndex = 0;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
              String rootpath=Properties.Settings.Default.Rootpath;
            if (cmbcountry.SelectedItem != null)
            {
                string statepath = Path.Join(rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");
                string[] content = txtstate.Text.Split("\r\n");
                File.WriteAllLines(statepath, content);
                MessageBox.Show("The state data is stored successfully");

            }

        }

        private void btnpreview_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void cmbcountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rootpath = Properties.Settings.Default.Rootpath;
            string statepath = Path.Join(rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");
            if (File.Exists(statepath))
            {
                String[] state = File.ReadAllLines(statepath);
                txtstate.Text = String.Join("\r\n", state);
            }
            else
            {
                txtstate.Text = " ";
            }

        }
    }
}
