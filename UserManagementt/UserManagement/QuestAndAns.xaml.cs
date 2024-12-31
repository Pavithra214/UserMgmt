using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;

namespace UserManagement
{
    /// <summary>
    /// Interaction logic for Quest_Ans.xaml
    /// </summary>
    public partial class Quest_Ans : Window
    {
        Boolean start = false;
        int answers = 0;
        int questions = 10;
        public Quest_Ans()
        {
            InitializeComponent();
        }

        private void CommonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (start)
            {
                RadioButton rbval = (RadioButton)sender;
                if (rbval.Tag.ToString() == "Y")
                {
                    int val = Convert.ToInt32(lblscr.Content);
                    val++;
                    lblscr.Content = val;
                }
                StackPanel stp = (StackPanel)rbval.Parent;
                int count = stp.Children.Count;
                for (int i = 0; i < count; i++)
                {
                    RadioButton rbbutton = (RadioButton)stp.Children[i];
                    rbbutton.IsEnabled = false;

                }
                answers++;
            }
            else
            {
                MessageBox.Show("Click on start before entering the Quiz");
            }
            
        }

        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            MessageBox.Show("Quiz started.All the best");
        }

        private void btnstop_Click(object sender, RoutedEventArgs e)
        {
            


            if (questions == answers)
            {
                start = false;
                MessageBox.Show("Your Score: " + lblscr.Content);
                lblscr.Content = "0";
            }

            else
            {
                MessageBox.Show("Kindly answer all the questions");
            }
        }
    }
}
