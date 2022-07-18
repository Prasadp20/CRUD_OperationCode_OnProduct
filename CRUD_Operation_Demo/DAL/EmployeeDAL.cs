using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CRUD_Operation_Demo.Models;

namespace CRUD_Operation_Demo.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> elist = new List<Employee>();
            string qry = "select * from Emp_Details";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Department = dr["Department"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.Age = Convert.ToInt32(dr["Age"]);
                    emp.Mobile_No = dr["Mobile_No"].ToString();
                    emp.Email_Id = dr["Email_Id"].ToString();
                    emp.City = dr["City"].ToString();
                    elist.Add(emp);
                }
            }
            con.Close();
            return elist;
        }

        public Employee GetEmployeeById(int Id)
        {
            Employee e = new Employee();
            string qry = "select * from Emp_Details where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Gender = dr["Gender"].ToString();
                    e.Department = dr["Department"].ToString();
                    e.Salary = Convert.ToDouble(dr["Salary"]);
                    e.Age = Convert.ToInt32(dr["Age"]);
                    e.Mobile_No = dr["Mobile_No"].ToString();
                    e.Email_Id = dr["Email_Id"].ToString();
                    e.City = dr["City"].ToString();
                }
            }
            con.Close();
            return e;
        }

        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Emp_Details values(@Name,@Gender,@Department,@Salary,@Age,@Mobile_No,@Email_Id,@City)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Age", emp.Age);
            cmd.Parameters.AddWithValue("@Mobile_No", emp.Mobile_No);
            cmd.Parameters.AddWithValue("@Email_Id", emp.Email_Id);
            cmd.Parameters.AddWithValue("@City", emp.City);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateEmployee(Employee emp)
        {
            string qry = "update Emp_Details set Name=@name,Gender=@gender,Department=@department,Salary=@salary,Age=@age,Mobile_No=@mobile_no,Email_Id=@email_id,City=@city where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@gender", emp.Gender);
            cmd.Parameters.AddWithValue("@department", emp.Department);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@mobile_no", emp.Mobile_No);
            cmd.Parameters.AddWithValue("@email_id", emp.Email_Id);
            cmd.Parameters.AddWithValue("@city", emp.City);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteEmployee(int Id)
        {
            string qry = "delete from Emp_Details where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
