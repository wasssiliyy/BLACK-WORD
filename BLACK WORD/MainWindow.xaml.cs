using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace BLACK_WORD
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

        string location = "";
        public bool IsClicked { get; set; } = false;

        private void copy_Button_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Copy();
        }

        private void select_All_Button_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.SelectAll();
            contentTxtb.Focus();
        }

        private void open_Button_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt";
            openDialog.FilterIndex = 2;


            if (openDialog.ShowDialog() == true)
            {
                using (var s = File.OpenText(openDialog.FileName))
                {
                    contentTxtb.Text = s.ReadToEnd();
                    location = Path.GetFullPath(openDialog.FileName);
                    sourceTxtbl.Text = location;
                }
            }
        }

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("It was succesfully", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
            File.WriteAllText(location, contentTxtb.Text);
            contentTxtb.Text = "";
            location = "";
            sourceTxtbl.Text = "";
        }

        private void cut_Button_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Cut();
        }

        private void paste_Button_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Paste();
        }

        private void saveCheck_Checked(object sender, RoutedEventArgs e)
        {
            IsClicked = true;
        }

        private void saveCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            IsClicked = false;
        }

        private void contentTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsClicked == true)
            {
                File.WriteAllText(location, contentTxtb.Text);
            }
        }
    }
}
