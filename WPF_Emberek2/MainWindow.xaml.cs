using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Emberek2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ember> list = new List<Ember>();
        public MainWindow()
        {
            InitializeComponent();
            
            list.Add(new Ember("Gipsz Jakab", 42));
            list.Add(new Ember("Lakatos Béla", 17));
            list.Add(new Ember("Kovács Ferenc", 58));

            emberek.ItemsSource = list;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int age = 0;
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxAge.Text))
            {
                MessageBox.Show("Töltse ki mindkét mezőt!");
            }
            else
            {
                try
                {
                    age = int.Parse(textBoxAge.Text);
                    if (age < 0 || age > 200)
                    {
                        MessageBox.Show("Helytelen életkor! (0-200 között)");
                    }
                    else
                    {
                        list.Add(new Ember(textBoxName.Text, age));
                        emberek.Items.Refresh();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Helytelen formátumú kor!");
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Ember selected = emberek.SelectedItem as Ember;

            if (selected == null)
            {
                MessageBox.Show("Válasszon ki egy törlendő adatsort!");
            }
            else
            {
                list.Remove(selected);
                emberek.Items.Refresh();
            }
        }
    }
}
