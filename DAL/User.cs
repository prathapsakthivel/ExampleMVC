using Dapper;
using ExampleMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMVC.DAL
{
    public class User
    {
        private string sqlConnectionString = @"Data Source = ANIYAAN-1006;initial catalog=prahap;user id=Anaiyaan;password=Anaiyaan@123";
        public List<UserModel> Select()
        {
            try
            {
                List<UserModel> ssp = new List<UserModel>();

                var connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                ssp = connection.Query<UserModel>("select*from CustomerModel").ToList();
                connection.Close();

                return ssp;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public UserModel Selectbyid(int id)
        {
            try
            {
                UserModel mod = new UserModel();
                var connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                mod = connection.Query<UserModel>($"select * from UserModel where Userid={id}").FirstOrDefault();
                connection.Close();

                return mod;


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public int Insert(UserModel CusName)
        {
            try
            {
                string UserName = CusName.UserName;
                DateTime DoB = CusName.DOB;
                string Email = CusName.EmailId;
                string Password = CusName.Password;
                long PhoneNumber = CusName.PhoneNumber;

                var connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                int rowsaffected = connection.Execute($"exec InsertSPW'{CusName.UserName}','{CusName.DOB.ToString("yyyy-MM-dd mm:ss")}','{CusName.EmailId}','{CusName.Password}','{CusName.PhoneNumber}','{CusName.Location}'");
                connection.Close();
                return rowsaffected;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(UserModel up)
        {
            try
            {
                var connection = new SqlConnection(sqlConnectionString);

                connection.Open();
                var affectedRows = connection.Execute($"exec UpdateSPW '{up.UserName}','{up.DOB.ToString("yyyy-MM-dd hh:mm")}','{up.EmailId}','{up.Password}','{up.PhoneNumber}', '{up.Location}'");
                connection.Close();
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int Delete(int Customerid)
        {
            try
            {
                var connection = new SqlConnection(sqlConnectionString);

                connection.Open();
                var affectedRows = connection.Execute($"exec DeleteSPW  {Customerid}");
                connection.Close();
                return affectedRows;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}

