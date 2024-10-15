using GYM_Training_Program.DTO.RequestDTO;
using GYM_Training_Program.DTO.ResponseDTO;

namespace GYM_Training_Program.IRepository
{
    public interface ITrainingProgramRepository
    {
        void AddTrainingProgram(TrainingProgramRequestDTO request);
        ICollection<TrainingProgramResponseDTO> GetAllTrainingProgram();
    }
}
