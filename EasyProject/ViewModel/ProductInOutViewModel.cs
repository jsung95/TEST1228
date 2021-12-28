using EasyProject.Dao;
using EasyProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;

namespace EasyProject.ViewModel
{
    public class ProductInOutViewModel : Notifier
    {
        ProductDao product_dao = new ProductDao();
        DeptDao dept_dao = new DeptDao();

        //입고 내역을 담을 프로퍼티
        private ObservableCollection<ProductInOutModel> product_in;
        public ObservableCollection<ProductInOutModel> Product_in
        {
            get { return product_in; }
            set
            {
                product_in = value;
                OnPropertyChanged("Product_in");
            }
        }
        private ObservableCollection<ProductInOutModel> product_out;
        //출고 내역을 담을 프로퍼티
        public ObservableCollection<ProductInOutModel> Product_out
        {
            get { return product_out; }
            set
            {
                product_out = value;
                OnPropertyChanged("Product_out");
            }
        }

        public ObservableCollection<DeptModel> Depts { get; set; }

        private DeptModel selectedDept_In;
        public DeptModel SelectedDept_In
        {
            get { return selectedDept_In; }
            set
            {
                selectedDept_In = value;
                OnPropertyChanged("SelectedDept_In");
                showInListByDept();
            }
        }

        private DeptModel selectedDept_Out;
        public DeptModel SelectedDept_Out
        {
            get { return selectedDept_Out; }
            set
            {
                selectedDept_Out = value;
                OnPropertyChanged("SelectedDept_Out");
                showOutListByDept();
            }
        }

        public string[] SearchTypeList { get; set; }
        public string searchKeyword_In { get; set; }
        public string searchKeyword_Out { get; set; }

        public string selectedSearchType_In { get; set; }
        public string selectedSearchType_Out { get; set; }

        public ProductInOutViewModel()
        {
            
            SearchTypeList = new[] { "제품코드", "제품명", "품목/종류" };
            selectedSearchType_In = SearchTypeList[0];

            Depts = new ObservableCollection<DeptModel>(dept_dao.GetDepts());
            SelectedDept_In = Depts[(int)App.nurse_dto.Dept_id - 1];
            Console.WriteLine("SelectedDept_In: " + SelectedDept_In.Dept_name);

            selectedSearchType_Out = SearchTypeList[0];
            SelectedDept_Out = Depts[(int)App.nurse_dto.Dept_id - 1];

            Product_in = new ObservableCollection<ProductInOutModel>(product_dao.GetProductIn(SelectedDept_In));
            Product_out = new ObservableCollection<ProductInOutModel>(product_dao.GetProductOut(SelectedDept_Out));

            

        }//Constructor


        private ActionCommand command;
        public ICommand Command
        {
            get
            {
                if (command == null)
                {
                    command = new ActionCommand(DoSomeThing);
                }
                return command;
            }//get

        }//Command

        public void DoSomeThing()
        {
            

        }// 

        private ActionCommand inSearchCommand;
        public ICommand InSearchCommand
        {
            get
            {
                if (inSearchCommand == null)
                {
                    inSearchCommand = new ActionCommand(InListSearch);
                }
                return inSearchCommand;
            }//get

        }//Command

        public void InListSearch()
        {
            Product_in = new ObservableCollection<ProductInOutModel>(product_dao.GetProductIn(SelectedDept_In, selectedSearchType_In, searchKeyword_In));

        }// InListSearch

        private ActionCommand outSearchCommand;
        public ICommand OutSearchCommand
        {
            get
            {
                if (outSearchCommand == null)
                {
                    outSearchCommand = new ActionCommand(OutListSearch);
                }
                return outSearchCommand;
            }//get

        }//Command

        public void OutListSearch()
        {
            Product_out = new ObservableCollection<ProductInOutModel>(product_dao.GetProductOut(SelectedDept_Out, selectedSearchType_Out, searchKeyword_Out));
       
        }// InListSearch

        public void showInListByDept()
        {
            Product_in = new ObservableCollection<ProductInOutModel>(product_dao.GetProductIn(SelectedDept_In));
           
        }//showInListByDept

        public void showOutListByDept()
        {
            Product_out = new ObservableCollection<ProductInOutModel>(product_dao.GetProductOut(SelectedDept_Out));
        
        }//showOutListByDept
    }//class

}//namespace
