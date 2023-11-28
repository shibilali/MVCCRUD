using MVCCRUD.Models;
using MVCCRUD.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCRUD.DAL
{
	public class EmpDAL : BaseService
	{
        public EmpDAL()
        {
        }
        public int Create(EmpModel empModel)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			string sqlQuery = String.Format("Insert into Employee (name,age,address,salary,email) Values('{0}', '{1}', '{2}', '{3}', '{4}');" + "Select @@Identity", empModel.Name, empModel.Age, empModel.Address, empModel.Salary,empModel.Email);
			command.CommandText = sqlQuery;
			sqlConnection.Open();
			int num = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return num;
		}
		public List<EmpModel> Read()
		{
			List<EmpModel> empList = new List<EmpModel>();
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			string sqlQuery = String.Format("select id,name,age,address,salary,email from Employee;");
			command.CommandText = sqlQuery;
			sqlConnection.Open();

			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			sqlDataAdapter.Fill(dt);

			foreach (DataRow dr in dt.Rows)
			{
				empList.Add(new EmpModel
				{
					Id = GetDBInt(dr["id"]),
					Age = GetDBInt(dr["age"]),
					Name =GetDBString(dr["name"].ToString()),
                    Address = GetDBString(dr["address"].ToString()),
                    Salary = GetDBInt(dr["salary"]),
                    Email = GetDBString(dr["email"].ToString())
                });
			}

			return empList;
		}

		public int Update(EmpModel empModel)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand();
			command.CommandText = string.Format("update Employee set name='{0}', age={1} where id={2};", empModel.Name, empModel.Age, empModel.Id);
			command.Connection = sqlConnection;

			sqlConnection.Open();
			int update = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return update;
		}

		public int Delete(EmpModel empModel)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand();
			command.CommandText = string.Format("delete from Employee where id={0};", empModel.Id);
			command.Connection = sqlConnection;

			sqlConnection.Open();
			int update = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return update;
		}

		public EmpModel GetEmployee(EmpModel empModel)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);
			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			command.CommandText = "select id,name,age,address,salary,email from Employee where id=@id;";
			command.Parameters.AddWithValue("@id", empModel.Id);
			sqlConnection.Open();

			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				empModel.Name = GetDBString(reader["name"]);
				empModel.Age = GetDBInt(reader["age"]);
                empModel.Address = GetDBString(reader["address"]);
                empModel.Salary = GetDBInt(reader["salary"]);
                empModel.Email = GetDBString(reader["email"]);
            }

			return empModel;
		}
	}
}
