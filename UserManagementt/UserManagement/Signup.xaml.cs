using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace UserManagement
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            //CultureInfo culture = new CultureInfo("ta-IN");
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            //this.Title = "Jsquare";
            this.Title = Properties.Settings.Default.company;
            cmbname.Items.Add("en-US");
            cmbname.Items.Add("ta-IN");
            cmbname.Items.Add("ms-SG");
            cmbname.Items.Add("ml-IN");
            cmbname.SelectedItem = Properties.Settings.Default.language;
        }
        private void cmbname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResourceManager rmanager = new ResourceManager("UserManagement.Property.Resource", Assembly.GetExecutingAssembly());
            Properties.Settings.Default.language = cmbname.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            //String lang = rmanager.GetString("langalert");
            //MessageBoxResult result = MessageBox.Show(lang, "JS Alert", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
        }

        private void btnsignin_Click(object sender, RoutedEventArgs e)
        {
            string userpath = Properties.Settings.Default.Rootpath + "//" + txtname.Text;
            if (Directory.Exists(userpath))
            {
                string filepath=Path.Join(userpath,txtname.Text+".txt");
                if (File.Exists(filepath))
                {
                    string values=File.ReadAllText(filepath);
                    string[] valuelist=values.Split('|');
                    if(txtname.Text==valuelist[0] && pwpassword.Password==valuelist[1])
                    {
                        MainWindow mainWindow = new MainWindow(txtname.Text);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        //This will be executed when the user provides the correct name but change the case. Eg:pavithra instead of Pavithra
                        MessageBox.Show("Check the user ID as it is case sensitive");
                    }
                }
                else
                {
                    MessageBox.Show("Invaid user ID and password");
                }
            }
            else
            {
                MessageBox.Show("Invalid user ID and password");
            }

            //if ((String.IsNullOrWhiteSpace(txtname.Text)) || (String.IsNullOrWhiteSpace(pwpassword.Password)))
            //        {
            //    MessageBox.Show("Please enter the user name and password");
            
           //else if (txtname.Text==pwpassword.Password) 
           // {
           //     MainWindow mainWindow = new MainWindow();
           //     mainWindow.Show();
           //     //mainWindow.ShowDialog();
           //     this.Close();
           // }
           // else
           // {
           //     MessageBox.Show("Invalid user name and password");
           // }
           
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
Registration registration = new Registration();
            registration.Show();
        }
    }
}
