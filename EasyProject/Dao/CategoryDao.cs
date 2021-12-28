using EasyProject.Model;
using EasyProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace EasyProject.Dao
{
    public class CategoryDao : CommonDBConn, ICategoryDao
    {
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> list = new List<CategoryModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT category_name FROM CATEGORY";

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CategoryModel dto = new CategoryModel()
                            {
                                Category_name = reader.GetString(0)
                            };

                            list.Add(dto);
                        }//while

                    }//using(cmd)

                }//conn

            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch

            return list;

        }//GetCategoris()


        public int GetCategory_ID(CategoryModel category_dto)
        {
            int category_id = 0;
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT category_id FROM CATEGORY WHERE category_name = :category_name";

                        cmd.Parameters.Add(new OracleParameter("category_name", category_dto.Category_name));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            category_id = reader.GetInt32(0);

                        }//while

                    }//using(cmd)

                }//conn

            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch

            return category_id;
        }//GetCategory_ID


    }//class

}//namespace
