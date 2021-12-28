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
    public class LoginDao : CommonDBConn, ILoginDao
    {       

        public NurseModel LoginUserInfo(NurseModel nurse_dto)
        {
            
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

                        cmd.CommandText = "SELECT * FROM NURSE WHERE nurse_no = :no AND nurse_pw = :pw";

                        cmd.Parameters.Add(new OracleParameter("no", nurse_dto.Nurse_no));
                        cmd.Parameters.Add(new OracleParameter("pw", SHA256Hash.StringToHash(nurse_dto.Nurse_pw)));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string nurse_no = reader.GetString(0);
                            string nurse_name = reader.GetString(1);
                            string nurse_auth = reader.GetString(2);
                            string nurse_pw = reader.GetString(3);
                            int? dept_id = reader.GetInt32(4);

                            nurse_dto.Nurse_no = nurse_no;
                            nurse_dto.Nurse_name = nurse_name;
                            nurse_dto.Nurse_auth = nurse_auth;
                            nurse_dto.Nurse_pw = nurse_pw;
                            nurse_dto.Dept_id = dept_id;
                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch

            return nurse_dto;
        }///LoginUserInfo

        public bool IdPasswordCheck(string nurse_no, string nurse_pw)
        {
            bool result = false;
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

                        cmd.CommandText = "SELECT * FROM NURSE WHERE nurse_no = :no AND nurse_pw = :pw";

                        cmd.Parameters.Add(new OracleParameter("no", nurse_no));
                        cmd.Parameters.Add(new OracleParameter("pw", SHA256Hash.StringToHash(nurse_pw)));

                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            result = true;
                        } else
                        {
                            result = false;
                        }

                    }//using(cmd)

                }//using(conn)

            }//try
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch

            return result;
        }//IdPasswordCheck

        public bool IdPasswordCheck(NurseModel nurse_dto)
        {
            bool result = false;
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

                        cmd.CommandText = "SELECT * FROM NURSE WHERE nurse_no = :no AND nurse_pw = :pw";

                        cmd.Parameters.Add(new OracleParameter("no", nurse_dto.Nurse_no));
                        cmd.Parameters.Add(new OracleParameter("pw", SHA256Hash.StringToHash(nurse_dto.Nurse_pw)));

                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch
            return result;
        }//IdPasswordCheck()

        public void PasswordChange(NurseModel nurse_dto, string newPassword)
        {
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

                        cmd.CommandText = "UPDATE Nurse SET " +
                                          "nurse_pw = :newPW " +
                                          "WHERE nurse_no = :no";

                        cmd.Parameters.Add(new OracleParameter("newPW", SHA256Hash.StringToHash(newPassword))); // 비밀번호 암호화
                        cmd.Parameters.Add(new OracleParameter("no", nurse_dto.Nurse_no));

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("비번변경!");
                    }//using(cmd)                    

                }//using(conn)

            }//try

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//catch

        }//PasswordChange


    }//class

}//namespace
