using Azure.Core;
using GYM_Training_Program.DTO.RequestDTO;
using GYM_Training_Program.DTO.ResponseDTO;
using GYM_Training_Program.IRepository;
using Microsoft.Data.SqlClient;

namespace GYM_Training_Program.Repository
{
    public class TrainingProgramRepository: ITrainingProgramRepository
    {
        private readonly string _connectionstring;

        public TrainingProgramRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void AddTrainingProgram(TrainingProgramRequestDTO request)
        {
            using(var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO TrainingProgram(Id,MemberId,Cardio,WeightTraining) VALUES(@id,@memberId,@cardio,@weighttraining)";
                command.Parameters.AddWithValue("id",request.Id);
                command.Parameters.AddWithValue("memberId",request.MemberId);
                command.Parameters.AddWithValue("cardio", request.Cardio);
                command.Parameters.AddWithValue("weighttraining", request.WeightTraining);
                command.ExecuteNonQuery();
            }
        }


        public ICollection<TrainingProgramResponseDTO> GetAllTrainingProgram()
        {
            var programList = new List<TrainingProgramResponseDTO>();
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM TrainingProgram";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var trainingProgramOBJ = new TrainingProgramResponseDTO()
                        {
                            Id = reader.GetString(0),
                            MemberId = reader.GetString(1),
                            Cardio = reader.GetString(2),
                            WeightTraining = reader.GetString(3),
                        };
                        programList.Add(trainingProgramOBJ);

                    }
                }
                
            }
            return programList;
        }

        public TrainingProgramResponseDTO GetTrainingProgramById(string ProgramId)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TrainingProgram WHERE Id == @id";
                command.Parameters.AddWithValue("@id", ProgramId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var trainingProgramOBJ = new TrainingProgramResponseDTO()
                        {
                            Id = reader.GetString(0),
                            MemberId = reader.GetString(1),
                            Cardio = reader.GetString(2),
                            WeightTraining = reader.GetString(3),
                        };
                    }
                    else
                    {
                        throw new Exception("Course Not Found!");
                    }
                };
            };
            return null;
        }

        public void UpdateProgram(string ProgramId)
        {

           
                using (var connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE TrainingProgram SET  WHERE Id == @id";
                    command.Parameters.AddWithValue("@id", ProgramId);
                     
                    command.ExecuteNonQuery();
                }
           

        }
    }
}
