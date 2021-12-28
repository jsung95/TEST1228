using EasyProject.Dao;
using EasyProject.Model;
using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace EasyProject.ViewModel
{
    public class PasswordChangeViewModel : Notifier
    {
        LoginDao dao = new LoginDao();

        public string Nurse_no { get; set; }
        public string Nurse_pw { get; set; }
        public NurseModel Nurse { get; set; }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged("NewPassword");
                OnNewPasswordChanged();
            }
        }
        private string re_NewPassword;
        public string Re_NewPassword
        {
            get { return re_NewPassword; }
            set
            {
                re_NewPassword = value;
                OnPropertyChanged("Re_NewPassword");
                OnNewPasswordChanged();
            }
        }
        private string newPasswordStatement;

        public string NewPasswordStatement
        {
            get { return newPasswordStatement; }
            set
            {
                newPasswordStatement = value;
                OnPropertyChanged("NewPasswordStatement");
            }
        }

        public PasswordChangeViewModel()
        {
            Nurse = new NurseModel();
            NewPassword = "";
            re_NewPassword = "";
        }

        //public ActionCommand command;

        //public ICommand Command
        //{
        //    get
        //    {
        //        if (command == null)
        //        {
        //            command = new ActionCommand(PasswordChange);
        //        }
        //        return command;
        //    }
        //}

        public bool PasswordChange()
        {
            bool pwChangeResult;
            if (dao.IdPasswordCheck(Nurse) == true) // 현재 아이디/비번이 맞는 지 확인
            {
                // 비밀번호 변경시 공백 입력 방지
                if (NewPassword == "")
                {
                    MessageBox.Show("새로운 비밀번호를 입력하세요!");
                    pwChangeResult = false;    
                    return pwChangeResult;
                }
                else if (Re_NewPassword == "")
                {
                    MessageBox.Show("다시 입력란을 채워주세요!");
                    pwChangeResult = false;
                    return pwChangeResult;
                }
                else if(NewPassword == Nurse.Nurse_pw)
                {
                    MessageBox.Show("현재 비밀번호와 다른 비밀번호를 입력해주세요!");
                    pwChangeResult = false;
                    return pwChangeResult;
                }
                // 새 비밀번호와 다시입력 같은지 확인
                else if (NewPassword == Re_NewPassword)
                {
                    MessageBox.Show("비밀번호 변경.");
                    dao.PasswordChange(Nurse, NewPassword);
                    //비밀번호 변경을 1회 진행하면서 바인딩 되어서 남겨진 데이터 초기화
                    Nurse.Nurse_no = null;
                    Nurse.Nurse_pw = null;

                    pwChangeResult = true;
                    return pwChangeResult;
                }
                else
                {
                    MessageBox.Show("새 비밀번호가 일치하지 않습니다.");
                    pwChangeResult = false;
                    return pwChangeResult;
                }
            }
            else
            {
                MessageBox.Show("아이디나 비밀번호를 다시 확인해주세요.");
                pwChangeResult = false;
                return pwChangeResult;
            }
        }//PasswordChange

        public void OnNewPasswordChanged()
        {
            if (NewPassword == "" || Re_NewPassword == "")
            {
                NewPasswordStatement = "";
            }
            else
            {
                if (NewPassword == Re_NewPassword)
                {
                    NewPasswordStatement = "두 비밀번호가 일치합니다.";
                }
                else
                {
                    NewPasswordStatement = "두 비밀번호가 일치하지 않습니다.";
                }
            }            
        }
    }//class
}//namespace
