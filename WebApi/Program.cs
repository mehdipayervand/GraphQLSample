using WebApi.StartupExtensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.ConfigureMongoDB(builder.Configuration);
        builder.Services.ConfigureApplicationServices(builder.Configuration);

        //builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //
        }

        //app.UseHttpsRedirection();
        //app.UseAuthorization();
        //app.MapControllers();

        app.Run();
    }
}