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
using EasyProject.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace EasyProject.View
{
    /// <summary>
    /// ReleasePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReleasePage : Page
    {
        public ReleasePage()
        {
            InitializeComponent();


        }




        private void reset_Btn_Click(object sender, RoutedEventArgs e)
        {

            mount_TxtBox_Hidden.Text = "";
        }

        private void cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate
               (
               new Uri("/View/TabItemPage/StatusPage.xaml", UriKind.Relative)
               );
        }

        private void signUp_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate
               (
               new Uri("/View/TabItemPage/StatusPage.xaml", UriKind.Relative)
               );
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = Ioc.Default.GetService<ProductShowViewModel>();

            if (Type_comboBox.SelectedValue != null)
            {
                if (Type_comboBox.SelectedValue.Equals("사용"))
                {
                    Dept_comboBox.Visibility = Visibility.Hidden;

                    mount_TxtBox.Text = null;

                    mount_TxtBox_Hidden.IsEnabled = true;
                    mount_TxtBox_Hidden.Visibility = Visibility.Hidden;
                }
                else if (Type_comboBox.SelectedValue.Equals("폐기"))
                {
                    Dept_comboBox.Visibility = Visibility.Hidden;

                    mount_TxtBox.Text = Convert.ToString(temp.SelectedProduct.Imp_dept_count);
                    mount_TxtBox.Focus();

                    mount_TxtBox_Hidden.Visibility = Visibility.Visible;
                    mount_TxtBox_Hidden.Text = Convert.ToString(temp.SelectedProduct.Imp_dept_count);
                    mount_TxtBox_Hidden.IsEnabled = false;

                    Console.WriteLine("ori : " + mount_TxtBox.Text);
                    Console.WriteLine("ori enable? : " + mount_TxtBox.IsEnabled);
                    Console.WriteLine("aft : " + mount_TxtBox_Hidden.Text);
                    Console.WriteLine("aft enable? : " + mount_TxtBox_Hidden.IsEnabled);
                }
                else
                {
                    Dept_comboBox.Visibility = Visibility.Visible;

                    mount_TxtBox.Text = null;

                    mount_TxtBox_Hidden.IsEnabled = true;
                    mount_TxtBox_Hidden.Visibility = Visibility.Hidden;
                }
            }

            /*ComboBox currentComboBox = sender as ComboBox;
            
            if (currentComboBox != null)
            {

                ComboBoxItem currentItem = currentComboBox.SelectedItem as ComboBoxItem;
                Console.WriteLine(currentItem);
                if (currentItem.Content.Equals("사용")|| currentItem.Content.Equals("폐기"))
                {
                    
                    Dept_comboBox.Visibility = Visibility.Hidden;
                }

                else
                {
                    Dept_comboBox.Visibility = Visibility.Visible;

                }

            }*/


        }
    }
}
