using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Services;

namespace Project_MovieWebAPIASPNETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //Add the DbContext 
            builder.Services.AddDbContext<MovieDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add the Configuration for the Movie AddTransient<IMovieService, MovieService>()
            //Need to Inject the DbContext in MovieService
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls= true);
            builder.Services.AddTransient<ICharacterService, CharacterService>();
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls =true);
            builder.Services.AddTransient<IFranchiseService, FranchiseService>();
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

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