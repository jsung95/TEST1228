using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyProject.Model;

namespace EasyProject.Dao
{
    public interface ICategoryDao
    {
        List<CategoryModel> GetCategories();
        int GetCategory_ID(CategoryModel category_dto);
    }//interface

}//namespace
