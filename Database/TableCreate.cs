using Microsoft.Data.SqlClient;

namespace GYM_Training_Program.Database
{
    public class TableCreate
    {
        private readonly string _connectionString;

        public TableCreate(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Tables()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                //provide Forign Key for Member ID when Merge The Code
                command.CommandText = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TrainingProgram')
                            BEGIN
                                    CREATE TABLE TrainingProgram(
                                        Id NVARCHAR(50) PRIMARY KEY,
                                        MemberId NVARCHAR(50) NOT NULL,
                                        Cardio NVARCHAR(50) NOT NULL,
                                        WeightTraining NVARCHAR(50) NOT NULL
                                    );
                            END
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
