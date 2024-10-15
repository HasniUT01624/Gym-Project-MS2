
using GYM_Training_Program.Database;
using GYM_Training_Program.IRepository;
using GYM_Training_Program.Repository;

namespace GYM_Training_Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DBConnection");

            builder.Services.AddSingleton<ITrainingProgramRepository>(obj => new TrainingProgramRepository(connectionString));



            var tableCreate = new TableCreate(connectionString);
            tableCreate.Tables();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
