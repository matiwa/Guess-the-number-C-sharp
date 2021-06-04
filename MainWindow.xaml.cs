using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Guess_the_number
{
    public partial class MainWindow : Window
    {
        private byte not;//number of tries
        private byte nd;//number drawn

        public MainWindow()
        {
            InitializeComponent();
            tv.IsEnabled = false;
            btncio.IsEnabled = false;
            tbean.IsEnabled = false;
        }

        private void btndan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A number between 1-100 was drawn.");
            not = 10; //resetting the number of trying
            MessageBox.Show("You have "+not+" tries to guess it.");
            //draw a number
            Random r = new Random();
            nd = Convert.ToByte(r.Next(1, 101));
            //the ability to guess the number
            tv.IsEnabled = true;
            btncio.IsEnabled = true;
            tbean.IsEnabled = true;
            tv.Content = "You have " + not + " tries.";
            //random number locked
            btndan.IsEnabled = false;
        }

        private void btncio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte ne = Convert.ToByte(tbean.Text);//number entered
                //wrong hit
                if (ne != nd && not > 0)
                {
                    if (ne < nd) MessageBox.Show("The number is too small", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    else if (ne > nd) MessageBox.Show("The number is too big", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    not--;
                    MessageBox.Show("Try again. You have " + not + " more tries.\r\n\r\n"
                        +"The number you are looking for is between 0 and 100.");
                    tv.Content = "You have " + not + " tries.";
                }
                else if (ne == nd)
                {
                    //number draw unlocked
                    btndan.IsEnabled = true;
                    //number quessing locked
                    btncio.IsEnabled = false;
                    tv.IsEnabled = false; tv.Content = "";
                    tbean.IsEnabled = false; tbean.Text = "";
                    //displaying the number
                    MessageBox.Show("Bravo!!! The drawn number is actually " + ne,"Win",MessageBoxButton.OK,
                        MessageBoxImage.Asterisk);
                }
                if (not < 1)
                {
                    //number draw unlocked
                    btndan.IsEnabled = true;
                    //number quessing locked
                    btncio.IsEnabled = false;
                    tv.IsEnabled = false; tv.Content = "";
                    tbean.IsEnabled = false; tbean.Text = "";
                    //displaying the number
                    MessageBox.Show("You were looking for a number " + nd, "Defeat", MessageBoxButton.OK,
                        MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btne_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); //closing the application
        }
    }
}
