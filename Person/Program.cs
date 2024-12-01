
using Person.Data;
using Person.Routes;

namespace Person
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        
            builder.Services.AddControllers();

            // Adicionar Swagger para documentação
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<PersonContext>();

            var app = builder.Build();

            // Configurações para desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.PersonRoutes();

            app.Run();
        }
    }
}
