using System.Windows;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace UserManagement
{
    /// <summary>
    /// Interaction logic for Forgot.xaml
    /// </summary>
    public partial class Forgot : Window
    {
        public Forgot()
        {
            InitializeComponent();
        }

        private void btnread_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(txtpath.Text))
                {
                txtvalue.Text = File.ReadAllText(txtpath.Text);
            }
            else
            {
                MessageBox.Show("File is not found to read");
            }
        }

        private void btnwrite_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(txtpath.Text, txtvalue.Text);
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete the file?", "JS", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (File.Exists(txtpath.Text))
                {
                    File.Delete(txtpath.Text);
                    MessageBox.Show("The file is deleted successfully");
                }

                else
                {
                    MessageBox.Show("The specified file is not found");
                }
            }
        }

        private void btncreatefolder_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(txtpath.Text))
            {
                MessageBox.Show("Enter the folder name");
            }
            else
            {
                Directory.CreateDirectory(txtpath.Text);
                MessageBox.Show("The folder is created successfully");
            }
            
        }

        private void btnfolderexists_Click(object sender, RoutedEventArgs e)
        {
            if(Directory.Exists(txtpath.Text))
            {
                MessageBox.Show("Yes,the folder exists");
            }
            else
            {
                MessageBox.Show("No,the specified folder doesnt exist");
            }
        }

        private void btnfolderdelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete the file?", "JS", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (Directory.Exists(txtpath.Text))
                {
                    Directory.Delete(txtpath.Text);
                    MessageBox.Show("The file is deleted successfully");
                }

                else
                {
                    MessageBox.Show("The specified file is not found");
                }
            }
        }

        private void btnfileextract_Click(object sender, RoutedEventArgs e)
        {
            String[] listfiles=Directory.GetFiles(txtpath.Text);
            LBfile.ItemsSource=listfiles;
        }
    }
}
