using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using appdb.models;

namespace appdb.services
{
    public class CourseService
    {

        private static string db_source = "dbserver868.database.windows.net";
        private static string db_user = "demousr";
        private static string db_password = "Demouser@123";
        private static string db_databse = "appdb";

        private SqlConnection GetConnection(string conn)
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_databse;
            return new SqlConnection(conn);

        }

        public IEnumerable<Course> GetCourses(string conn)
        {
            List<Course> _list = new List<Course>();
            string statement = "select * from dbo.Course";
            SqlConnection conn1 = GetConnection(conn);
            conn1.Open();
            SqlCommand sqlCommand = new SqlCommand(statement, conn1);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course c = new Course
                    {
                        CourseID = reader.GetInt32(0),
                        CourseName = reader.GetString(1),
                        Rating = reader.GetDecimal(2),
                    };
                    _list.Add(c);

                }
            }
            conn1.Close();
            return _list;
        }

    }
}
