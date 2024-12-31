using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace UserManagement.UI
{
    /// <summary>
    /// Interaction logic for Skills.xaml
    /// </summary>
    public partial class Skills : Page
    {
        public Skills()
        {
            InitializeComponent();
            string path = Properties.Settings.Default.Rootpath;
            string skillpath = path + "//MasterData" + "//Skills.txt";
            string[] val=File.ReadAllLines(skillpath);
            txtskills.Text = String.Join("\r\n",val);
            


        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string path = Properties.Settings.Default.Rootpath;
            string skillpath = path + "//MasterData" + "//Skills.txt";
            string[] skillcontent = txtskills.Text.Split("\r\n");
            File.WriteAllLines(skillpath, skillcontent);
            MessageBox.Show("The skill data is saved successfully");

        }

        private void btnpreview_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
