using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOnet
{
    class PatientDoctor
    {
        public int id { get; set; }
        public string PatienName { get; set; }
        public string DoctorName{ get; set; }
     }
    class Program
    {
        static void Main(string[] args)
        {
            List<PatientDoctor> listPd = new List<PatientDoctor>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=D07\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=true";
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select p.id as PatientId, p.name as PatientName , d.name as DoctorName from Patient p
                                            left join PatientDoctor pd on pd.PatientId= p.id
                                            left join Doctor d on pd.DoctorId =d.id";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPd.Add(new PatientDoctor
                            {
                                id = (int)reader["PatientId"],
                                PatienName = reader["PatientName"] != DBNull.Value ? (string)reader["PatientName"] : string.Empty,
                                DoctorName= reader["DoctorName"] != DBNull.Value ? (string)reader["DoctorName"]: string.Empty
                            });
                        }
                    }
                }
            }
            var group= listPd.select
            foreach (PatientDoctor item in listPd)
            {
                Console.WriteLine(item.id +" "+item.PatienName +" \n\t\t"+item.DoctorName );
            }
        }
    }
}
