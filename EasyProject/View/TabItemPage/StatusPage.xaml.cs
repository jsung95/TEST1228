using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System;
using System.Linq;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Collections;
using EasyProject.Model;
using System.ComponentModel;
namespace EasyProject.View.TabItemPage
{
    /// <summary>
    /// StatusPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    /// 
    public partial class StatusPage : Page 
    {
        //int pIndex = 1;
        //private int numberOf;
        public ChartValues<float> Values { get; set; }
        private enum PagingMode
        { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        List<object> myLst = new List<object>();

        public String userDept = null;

        public bool isComboBoxDropDownOpened = false;
        //public WindowStartupLocation WindowStartupLocation { get; }

        public StatusPage()
        {
            InitializeComponent();
            //cbNumberOfRecords.Items.Add("10");
            //cbNumberOfRecords.Items.Add("20");
            //cbNumberOfRecords.Items.Add("30");
            //cbNumberOfRecords.Items.Add("50");
            //cbNumberOfRecords.Items.Add("100");
            //cbNumberOfRecords.SelectedItem = 10;
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            deptName_ComboBox1.SelectedIndex = (int)App.nurse_dto.Dept_id - 1;
            this.Loaded += MainWindow_Loaded;

            userDept = (deptName_ComboBox1.SelectedValue as DeptModel).Dept_name;


        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            searchText_ComboBox.Items.Add("제품코드");
            searchText_ComboBox.Items.Add("제품명");
            searchText_ComboBox.Items.Add("품목/종류");
            searchText_ComboBox.SelectedIndex = 0;
            
        }
       
        private void RowButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼을 클릭했습니다.");
        }
        //#region Pagination 
        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            //Navigate((int)PagingMode.First);
        }
        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            //Navigate((int)PagingMode.First);
        }
        private void btnLast_Click(object sender, System.EventArgs e)
        {
            //Navigate((int)PagingMode.First);
        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            //Navigate((int)PagingMode.First);
        }

        //    genericList.Add((object)Clipboard.GetData(DataFormats.CommaSeparatedValue));

        //    //Student studentObj;
        //    //Random randomObj = new Random();
        //    //for (int i = 0; i < 1000; i++)
        //    //{
        //    //    studentObj = new Student();
        //    //    studentObj.ProductCode = "ProductCode " + i;
        //    //    studentObj.ProductName = "ProductName " + i;
        //    //    studentObj.Category = "Category " + i;
        //    //    studentObj.Total = "Total " + i;
        //    //    studentObj.User = "User " + i;
        //    //    studentObj.ExpirationDate = "ExpirationDate " + i;
        //    //    studentObj.UseDate = "UseDate " + i;
        //    //    studentObj.StateContent = "StateContent " + i;

        //    //    //studentObj.Age = (uint)randomObj.Next(1, 100);

        //    //    genericList.Add(studentObj);
        //    //    //dataGrid.Items.dd(studentObj);
        //    //}

        //    return genericList;
        //}

        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Navigate((int)PagingMode.PageCountChange);
        }
        private void Part_comboBox_Selection (object sender, SelectedCellsChangedEventArgs e)
        {
            MessageBox.Show("버튼을 클릭했습니다.");
        }
       
        private void goDialog_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate
                (
                new Uri("/View/ExportPage/DialogPage.xaml", UriKind.Relative)
                );
        }

        private void OnDropDownOpened(object sender, EventArgs e)
        {
            isComboBoxDropDownOpened = true;

            var deptModelObject = deptName_ComboBox1.SelectedValue as DeptModel;
            var deptNameText = deptModelObject.Dept_name;
            var userText = userDept;

            if (isComboBoxDropDownOpened)
            {

                if (deptNameText.Equals(userText) || userText == null)
                {
                    Console.WriteLine(userText + "같은 부서일때");
                    buttonColumn.Visibility = Visibility.Visible;
                }
                else
                {
                    Console.WriteLine(userText + "다른 부서일때");
                    buttonColumn.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
