using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace Task7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ObservableCollection<Helicopter> helicoptersList = new ObservableCollection<Helicopter>();

        public MainWindow()
        {
            InitializeComponent();

            Helicopter helicopter1 = new Helicopter($"Jonny", "Boeing", new Coords(100, 100), 4800, true);
            Helicopter helicopter2 = new Helicopter($"Sunny", "Lockheed", new Coords(0, 0), 6100, false);
            Helicopter helicopter3 = new Helicopter($"Will", "Apache", new Coords(900, 300), 3902, true);
            Helicopter helicopter4 = new Helicopter(helicopter1) { Name = "April" };
            Helicopter helicopter5 = new Helicopter(helicopter2) { Name = "Mary" };
            Helicopter helicopter6 = new Helicopter(helicopter1) { Name = "Moon" };

            helicoptersList.Add(helicopter1);
            helicoptersList.Add(helicopter2);
            helicoptersList.Add(helicopter3);
            helicoptersList.Add(helicopter4);
            helicoptersList.Add(helicopter5);
            helicoptersList.Add(helicopter6);

            EnterField_Helicopters_List.ItemsSource = helicoptersList;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Do you really want to Exit?", "       ~~~~  Exit Message ~~~~~",
                MessageBoxButton.YesNo,
                MessageBoxImage.Error);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private bool TryCreateHelicopter(out Helicopter helicopter)

        {
            helicopter = null;

            string tempName = "";
            if (EnterField_Name.Text.Length > 0)
            {
                tempName = EnterField_Name.Text;
            }
            else
            {
                MessageBox.Show(
                    "Enter NAME please",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            string tempModel = "";
            if (EnterField_Model.Text.Length > 0)
            {
                tempModel = EnterField_Model.Text;
            }
            else
            {
                MessageBox.Show(
                    "Enter MODEL please",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            int tempLatitude = 0;

            if ((Int32.TryParse(EnterField_Latitude.Text, out tempLatitude)) != true)
            {
                MessageBox.Show(
                    "As Position is avaliable to enter only numbers",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            int tempLongitude = 0;

            if ((Int32.TryParse(EnterField_Longitude.Text, out tempLongitude)) != true)
            {
                MessageBox.Show(
                    "As Position is avaliable to enter only numbers",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            int tempWeight = 0;

            if (Int32.TryParse(EnterField_Weight.Text, out tempWeight) == true)
            {
                if (tempWeight < 100 && tempWeight > 20000)
                {
                    MessageBox.Show(
                        "Weight have to be in range between 100 and 20000",
                        "       ~~~~  Warning Message ~~~~~",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(
                    "Weight have to consist from numbers",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            if (RadioButton_Armed_No.IsChecked == RadioButton_Armed_Yes.IsChecked)
            {
                MessageBox.Show(
                    "Choose Armed flag.",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }


            helicopter = new Helicopter();

            helicopter.Name = tempName;
            helicopter.Model = tempModel;
            helicopter.Position.Latitude = tempLatitude;
            helicopter.Position.Longitude = tempLongitude;
            helicopter.Weight = tempWeight;

            if (RadioButton_Armed_Yes.IsChecked == true)
            {
                helicopter.Armed = true;
            }

            else
            {
                helicopter.Armed = false;
            }

            EnterField_Name.Text = "";
            EnterField_Model.Text = "";
            EnterField_Latitude.Text = "";
            EnterField_Longitude.Text = "";
            EnterField_Weight.Text = "";

            RadioButton_Armed_Yes.IsChecked = false;
            RadioButton_Armed_No.IsChecked = false;


            return true;

        }
        
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {            
            Helicopter helic;

            if (this.TryCreateHelicopter(out helic))
            {
                helicoptersList.Add(helic);
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EnterField_Helicopters_List.SelectedIndex != -1)
            {
                helicoptersList.RemoveAt(EnterField_Helicopters_List.SelectedIndex);
            }
            else
            {
                MessageBox.Show(
                    "Choose helicopter from list",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }
        }

        private void EnterField_Longitude_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {

            //int tempLongitude = 0;

            //char firstElement = EnterField_Latitude.Text[0];

            //e.Key == Key.

            //if (Char.IsDigit(firstElement))
            //{
            //    tempLongitude = Convert.ToInt32(EnterField_Longitude.Text);
            //}

            //else
            //{
            //    MessageBox.Show("As Position is avaliable to enter only numbers");

            //    return;
            //}


        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

            if (EnterField_Name.Text != "" && EnterField_Model.Text != "" && EnterField_Weight.Text != "" && EnterField_Latitude.Text != ""
            && EnterField_Longitude.Text != "" && ((RadioButton_Armed_Yes.IsChecked == true) || (RadioButton_Armed_No.IsChecked == true)))

            {

                if (EnterField_Helicopters_List.SelectedIndex != -1)

                {
                    Helicopter helic;

                    if (this.TryCreateHelicopter(out helic))
                    {
                        int indexNum = EnterField_Helicopters_List.SelectedIndex;
                        helicoptersList[indexNum] = helic;

                        //helicoptersList.RemoveAt(indexNum);

                        //helicoptersList.Insert(indexNum, helic);
                    }

                }
                else
                {
                    MessageBox.Show(
                        "Choose helicopter from list",
                        "       ~~~~  Warning Message ~~~~~",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }

            else
            {

                MessageBox.Show(
                    "Enter all parametres",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
        }
        
        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (EnterField_Helicopters_List.SelectedIndex != -1)

            {
                Helicopter helic;
                
                    int indexNum = EnterField_Helicopters_List.SelectedIndex;
                    helic=helicoptersList[indexNum];
                    helicoptersList.Add(helic);
            }
            else
            {
                MessageBox.Show(
                    "Choose helicopter from list",
                    "       ~~~~  Warning Message ~~~~~",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

        }

        private void Button_ArmedInfo_Click(object sender, RoutedEventArgs e)
        {

            int countArmed = 0;

            for (int i = 0; i < helicoptersList.Count; i++)
            {

                if (helicoptersList[i].Armed == true)
                {
                    ++countArmed;
                }
            }

            MessageBox.Show($"Number of ARMED helicopters: {countArmed}\n\nNumber of NOT ARMED helicopters: {helicoptersList.Count - countArmed}",
                "       ~~~~ Armed Information Message ~~~~~",
                MessageBoxButton.OK,
                MessageBoxImage.Information);


        }
        
    }
}
