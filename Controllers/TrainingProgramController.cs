using GYM_Training_Program.DTO.RequestDTO;
using GYM_Training_Program.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Training_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingProgramController : ControllerBase
    {
        private readonly ITrainingProgramRepository _trainingProgramRepository;

        public TrainingProgramController(ITrainingProgramRepository trainingProgramRepository)
        {
            _trainingProgramRepository = trainingProgramRepository;
        }


        [HttpPost("Add-TrainingProgram")]

        public IActionResult AddTrainingProgram([FromForm] TrainingProgramRequestDTO request)
        {
            _trainingProgramRepository.AddTrainingProgram(request);
            return Ok(request);
        }

        [HttpGet("Get-All-TrainingProgram")]

        public IActionResult GetAllTrainingProgram()
        {
            var TrainingProgramsList = _trainingProgramRepository.GetAllTrainingProgram();
            return Ok(TrainingProgramsList);
        }

        [HttpGet("Get-TrainingProgram-By-ID /{ProgramId}")]

        public IActionResult  GetTrainingProgramById(string ProgramId)
        {
           try
           {
               var Program = _trainingProgramRepository.GetTrainingProgramById(ProgramId);
               return Ok(Program);
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
        }

        [HttpPut("Update-Program/{ProgramId}")]

        public IActionResult UpdateProgram(string ProgramId)
        {
            try
            {
                _trainingProgramRepository.UpdateProgram(ProgramId);
                return Ok("Program Updated Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
