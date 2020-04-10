using ExamTwoCodeQuestions.Data;
using System;
using System.Collections.Generic;
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

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
            DataContextChanged += OnFruitChanged;
            FlavorPeach.Click += FruitFillingChangedClicked;
            FlavorCherry.Click += FruitFillingChangedClicked;
            FlavorBlueberry.Click += FruitFillingChangedClicked;
        }
        
        /// <summary>
        /// Calls the Flavor change method to invoke when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFruitChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FruitFillingChanged();
        }
        /// <summary>
        /// Changes the radio button depending on the enum that the user wants to set the fruit filling to.
        /// </summary>
        private void FruitFillingChanged()
        {
            if (DataContext is Cobbler cobbler)
            {
                switch (cobbler.Fruit)
                {
                    default:
                    case FruitFilling.Peach:
                        FlavorPeach.IsChecked = true;
                        FlavorCherry.IsChecked = false;
                        FlavorBlueberry.IsChecked = false;
                        break;
                    case FruitFilling.Cherry:
                        FlavorPeach.IsChecked = false;
                        FlavorCherry.IsChecked = true;
                        FlavorBlueberry.IsChecked = false;
                        break;
                    case FruitFilling.Blueberry:
                        FlavorPeach.IsChecked = false;
                        FlavorCherry.IsChecked = false;
                        FlavorBlueberry.IsChecked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// Manually binds the fruit filling flavors to the buttons to display elsewhere in the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FruitFillingChangedClicked(object sender, EventArgs e)
        {
            if (sender is RadioButton radio)
            {
                if (DataContext is Cobbler cobbler)
                {
                    switch (radio.Name)
                    {
                        default:
                        case "FlavorPeach":
                            cobbler.Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Peach;
                            FruitFillingChanged();
                            break;
                        case "FlavorCherry":
                            cobbler.Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Cherry;
                            FruitFillingChanged();
                            break;
                        case "FlavorBlueberry":
                            cobbler.Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Blueberry;
                            FruitFillingChanged();
                            break;
                    }
                }
            }
        }
    }
}
