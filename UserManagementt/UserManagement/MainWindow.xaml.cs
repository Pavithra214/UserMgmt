using System.Windows;
using UserManagement.UI;
using System.IO;
using System.Windows.Controls;
namespace UserManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Home home;
        User user;
        ListUser userlist;
    
        public MainWindow(string username)
        {
           
            InitializeComponent();
          
            lbluser.Content = username;
            home = new Home();
            user = new User();
            userlist = new ListUser();
            framename.Content= home;
          
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

            framename.Content = home;

        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
           Registration registration = new Registration(lbluser.Content.ToString());
            registration.Show();
            //framename.Content = user;
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
          
            framename.Content=userlist;
        }

        //private void backbtn_Click(object sender, RoutedEventArgs e)
        //{
        //   if(framename.CanGoBack)
        //    {
        //        framename.GoBack();
        //    }
        //}

        //private void frwdbtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if(framename.CanGoForward)
        //    {
        //        framename.GoForward();
        //    }
        //}

        private void Master_Click(object sender, RoutedEventArgs e)
        {
            MenuItem val=(MenuItem)sender;
            String menu = val.Header.ToString();
            if(menu=="Skills")
            {
                framename.Content = new Skills();

            }
            else if(menu=="Country")
            {
                framename.Content = new Country();
            }
            else if(menu=="State")
            {
                framename.Content= new State();
            }
            else if(menu=="City")
            {
                framename.Content = new City();
            }
        }

    }
}