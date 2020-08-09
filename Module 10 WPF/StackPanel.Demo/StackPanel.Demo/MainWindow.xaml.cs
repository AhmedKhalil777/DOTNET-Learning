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

namespace StackPanel.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DescriptionText.Text);

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            WeldCheckBox.IsChecked =
         AssemblyCheckBox.IsChecked =
         PlasmaCheckBox.IsChecked =
         LaserCheckBox.IsChecked =
         PurchaceCheckBox.IsChecked =
         LatheCheckBox.IsChecked =
         DrillCheckBox.IsChecked =
         FoldCheckBox.IsChecked =
         RollCheckBox.IsChecked =
         SawCheckBox.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            var checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                int x =int.Parse(LengthTextBox.Text);
                LengthTextBox.Text = (++x).ToString();
            }
            else
            {
                int x = int.Parse(LengthTextBox.Text);
                LengthTextBox.Text = (--x).ToString();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

                int x = int.Parse(LengthTextBox.Text);
                LengthTextBox.Text = (--x).ToString();
           

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteText == null)
            {
                return;
            }
            var compo = (ComboBox)sender;
            var selected = (ComboBoxItem)compo.SelectedValue;
            NoteText.Text = (string)selected.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(RubberingCombo, null);
        }
    }
}
