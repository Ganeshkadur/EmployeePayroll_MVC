using Employee_Repository.Entities;
using Employee_Repository.Interfaces;
using ModelLayer.RequestModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Employee_RepositoryLayer.Services
{
    public class EmployeeRepo:IEmployee_Repository
    {
       string _connectionString = @"Data Source=NIMBUS2000\SQLEXPRESS;Initial Catalog=Employee_payroll_MVC;Integrated Security=True;";
        

        public IEnumerable<Employee> GetAllEmployees()
        {
            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<Employee> list = new List<Employee>();

                // sqlConnection = new SqlConnection(_connectionString);

                con.Open();
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = (int)Convert.ToInt64(rdr["EmployeeID"]);
                    emp.FullName = rdr["FullName"].ToString();
                    emp.Department = rdr["Department"].ToString();
                    emp.ImagePath = rdr["ImagePath"].ToString();
                    emp.Salary = Convert.ToDecimal(rdr["Salary"]);
                    emp.Gender = rdr["Gender"].ToString();
                    emp.StartDate = DateTime.Parse(rdr["StartDate"].ToString());
                    emp.Notes = rdr["Notes"].ToString();
                    list.Add(emp);
                }
                con.Close();
                return list;
            }
            
          

        }



        public void CreateEmployee(EmployeeModel employee)
        {
            //sqlConnection = new SqlConnection(_connectionString);

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("spInsertEmployee",con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
                sqlCommand.Parameters.AddWithValue("@ImagePath", employee.ImagePath);
                sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                sqlCommand.Parameters.AddWithValue("@Notes", employee.Notes);

                int result = sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }



        public Employee GetElementById(int id)
        {

                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
               
                    SqlCommand sqlCommand = new SqlCommand("GetEmployeeById", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                    SqlDataReader rdr = sqlCommand.ExecuteReader();
                    if (rdr.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmployeeId = Convert.ToInt32(rdr["EmployeeID"]),
                            FullName = rdr["FullName"].ToString(),
                            Department = rdr["Department"].ToString(),
                            ImagePath = rdr["ImagePath"].ToString(),
                            Salary = Convert.ToDecimal(rdr["Salary"]),
                            Gender = rdr["Gender"].ToString(),
                            StartDate = DateTime.Parse(rdr["StartDate"].ToString()),
                            Notes = rdr["Notes"].ToString()
                        };
                        rdr.Close();
                        sqlConnection.Close();
                        return emp;

                    }
                    rdr.Close();
                    sqlConnection.Close();
                    return null;
                }

        }

         public void DeleteEmployeeById(int id)
           {
               //sqlConnection = new SqlConnection(_connectionString);
               using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
               {
                   sqlConnection.Open();

                   SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeById1", sqlConnection);
                   sqlCommand.CommandType = CommandType.StoredProcedure;
                   sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                   int res = sqlCommand.ExecuteNonQuery();
                   sqlConnection.Close();
               }


           }

        public Employee UpdateEmployeeById(Employee employee)
        {
            // sqlConnection = new SqlConnection(_connectionString);
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                sqlCommand.Parameters.AddWithValue("@FullName", employee.FullName);
                sqlCommand.Parameters.AddWithValue("@ImagePath", employee.ImagePath);
                sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                sqlCommand.Parameters.AddWithValue("@Notes", employee.Notes);

                sqlCommand.ExecuteNonQuery();
                con.Close();
                return employee;
            }
           

        }


        public Employee Login(int id, string name)
        {
            Employee employee = new Employee();

           
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "select * from Employee where EmployeeId = " + id + " AND FullName = '" + name + "'";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.FullName = rdr["FullName"].ToString();

                }

                if (rdr.HasRows)
                {
                    return employee;
                }
            }
            return null;
        }

        public IEnumerable<Employee> GetEmployeesByName(string name)
        {
            using(SqlConnection con=new SqlConnection(_connectionString))
            {
                con.Open();
                List<Employee> list = new List<Employee>(); 
                SqlCommand cmd = new SqlCommand("GetEmployeebyName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                SqlDataReader result=cmd.ExecuteReader();
                while(result.Read())
                {
                    Employee emp = new Employee
                    {
                        EmployeeId = Convert.ToInt32(result["EmployeeId"]),
                        FullName = result["FullName"].ToString(),
                        Gender = result["Gender"].ToString(),
                        Department = result["Department"].ToString(),
                        ImagePath = result["ImagePath"].ToString(),
                        Notes = result["Notes"].ToString(),
                        Salary = Convert.ToDecimal(result["Salary"]),
                        StartDate = DateTime.Parse(result["StartDate"].ToString())

                    };
                    list.Add(emp);

                }
                con.Close();
                return list;
            }

           
        }

      
    }
}
