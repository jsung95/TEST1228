using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyProject.Model;

namespace EasyProject.Dao
{
    public interface ILoginDao
    {
        NurseModel LoginUserInfo(NurseModel nurse_dto);
        bool IdPasswordCheck(string nurse_no, string nurse_pw);
        bool IdPasswordCheck(NurseModel nurse_dto);

        void PasswordChange(NurseModel nurse_dto, string newPassword);
    }//interface

}//namespace
