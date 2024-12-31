using System.Windows;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace UserManagement
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string Rootpath;
        string name;
        public Registration(string username="")
        {
            
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
            name = username;
            Rootpath = System.Environment.SpecialFolder.CommonApplicationData.ToString();
            Rootpath = Rootpath + "//JSUserManagement";
            if(!Directory.Exists(Rootpath))
            {
                Directory.CreateDirectory(Rootpath);
            }

            UserManagement.Properties.Settings.Default.Rootpath= Rootpath;
            UserManagement.Properties.Settings.Default.Save();

            //Skill Binding
            string skillpath = Path.Join(Rootpath, "MasterData", "Skills.txt");
            string[] skill = File.ReadAllLines(skillpath);
            lstskill.ItemsSource = skill;


            //Country Binding
            string[] country = File.ReadAllLines(Rootpath + "//MasterData" + "//Country.txt");
            cmbcountry.ItemsSource = country;

            //username=value

            string userpath = Properties.Settings.Default.Rootpath + "//" + name;
            if (Directory.Exists(userpath))
            {
                string filepath = Path.Join(userpath, name + ".txt");
                if (File.Exists(filepath))
                {
                    string values = File.ReadAllText(filepath);
                    string[] listvalues = values.Split("|");
                    txtname.Text = listvalues[0];
                    pbpwd.Password = listvalues[1];
                    txtage.Text = listvalues[2];
                    txtemail.Text = listvalues[3];
                    txtphone.Text = listvalues[4];
                    string gen = listvalues[5];
                    if (rbmale.IsChecked == true)
                    {
                        gen = rbmale.Content.ToString();
                    }
                    else
                    {
                        gen = rbfemale.Content.ToString();
                    }
                    lstskill.SelectedItem = listvalues[6];
                    cmbcountry.SelectedItem = listvalues[7];
                    cmbstate.SelectedItem = listvalues[8];
                    cmbcity.SelectedItem = listvalues[9];
                }
            }





            //state Binding
            //string statepath = Path.Join(Rootpath, "MasterData", "state", cmbcountry.SelectedItem + ".txt");
            //string[] state=File.ReadAllLines(statepath);
            //cmbstate.ItemsSource = state;
            


            //string[] country = { "India", "Africa", "Thailand", "Bangkok" };
            //cmbcountry.ItemsSource = country;
            cmbcountry.SelectedIndex = 0;
            //string[] state = { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka", "Kerala", "Maharashtra", "Madhya Pradesh", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Tripura", "Telangana", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
            //cmbstate.ItemsSource = state;
            
            
            //cmbname.Items.Add("en-US");
            //cmbname.Items.Add("ta-IN");
            //cmbname.Items.Add("ms-SG");
            //cmbname.Items.Add("ml-IN");
            //cmbname.SelectedItem = Properties.Settings.Default.language;
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            //File Creation:
            //File.Create("D:\\FileConcept\\user.txt");

            //File.WriteAllText("D:\\FileConcept\\Pavi.txt", "Welcome to Jsquare");
            //if(File.Exists("D:\\FileConcept\\user.txt"))
            //{
            //    File.Delete("D:\\FileConcept\\user.txt");
            //}
            //else
            //{
            //    MessageBox.Show("The file is not found");
            //} 
            string gender;
            if (rbmale.IsChecked == true)
            {
                gender = rbmale.Content.ToString();
            }
            else
            {
                gender=rbfemale.Content.ToString();
            }



            String userpath = Properties.Settings.Default.Rootpath + "/" + txtname.Text;
            if(!Directory.Exists(userpath))
            {
                Directory.CreateDirectory(userpath);
                String filename = userpath + "/" + txtname.Text + ".txt";
                string content=$"{txtname.Text}|{pbpwd.Password}|{txtage.Text}|{txtemail.Text}|{txtphone.Text}|{gender}|{lstskill.SelectedItem}|{cmbcountry.SelectedItem}|{cmbstate.SelectedItem}|{cmbcity.SelectedItem}";
                File.WriteAllText(filename, content);
                MessageBox.Show("Congratulations! The Registration is successful");
            }
            else

            {
                MessageBox.Show("The user name already exists.Please choose a different user name");
            }
        }

        private void cmbname_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ResourceManager rmanager=new ResourceManager("UserManagement.Property.Resource",Assembly.GetExecutingAssembly());
            Properties.Settings.Default.language=cmbname.SelectedItem.ToString();
            Properties.Settings.Default.Save();


        }

        private void cmbcountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //State Binding

            string statepath = Path.Join(Rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");
            string[] state = File.ReadAllLines(statepath);
         
            cmbstate.ItemsSource = state;

            
            
               
            
        }

        private void cmbstate_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //City Binding
           
                string citypath = Path.Join(Rootpath, "MasterData", "city", cmbcountry.SelectedItem.ToString(), cmbstate.SelectedItem + ".txt");
            if (File.Exists(citypath))
            {

                string[] city = File.ReadAllLines(citypath);

                cmbcity.ItemsSource = city;

            }
           
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
