using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTask
{
    internal class StudentService
    {
        private readonly Sql _sql = new Sql();
        private readonly string _connection = "Server=.;Database=Students;Trusted_Connection=True;";

        public void Add(Student student)
        {
            try
            {
                string query = ($"INSERT INTO Students (Name, Surname, Age) " )+ ($"VALUES ('{student.Name}', '{student.Surname}', {student.Age})");

                int result = _sql.ExecuteCommand(query);

                if (result > 0)
                {
                    Console.WriteLine("Completed successfully");
                }
                else
                {
                    Console.WriteLine("Error occured");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public Student Get(int id)
        {
            Student student = null;
            SqlConnection conn = new SqlConnection(_connection);
            try
            {
                conn.Open();
                string query = ($"SELECT Id, Name, Surname, Age FROM Students WHERE Id={id}");
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Age = (int)reader["Age"]
                    };
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            finally
            {
                conn.Close();
            }
            return student;
        }

        public void Update(Student student)
        {
            try
            {
                string query = ($"UPDATE Students SET ") + ($"Name='{student.Name}', Surname='{student.Surname}', Age={student.Age} ") +($"WHERE Id={student.Id}");

                int result = _sql.ExecuteCommand(query);

                if (result > 0)
                {
                    Console.WriteLine("Updated successfully");
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }


        public void Remove(int id)
        {
            try
            {
                string query = ($"DELETE FROM Students WHERE Id={id}");
                int result = _sql.ExecuteCommand(query);

                if (result > 0)
                {
                    Console.WriteLine("Student deleted successfully");
                }
                else
                {
                    Console.WriteLine("Student not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}

