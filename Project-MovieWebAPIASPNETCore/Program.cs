using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Services;
using System.Reflection;

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
            //Add AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Add XML filen
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile) ;

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo //Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "(yet another) Movie API",
                    Description ="YET ANOTHER MOVIE API",
                    Contact = new OpenApiContact
                    {
                        Name="Tommy and Maryam",
                        Url = new Uri("https://github.com/tommy-ph/Project-MovieWebAPIASPNETCore")
                    },
                    License = new OpenApiLicense
                    {
                        Name= "Noroff 2023",
                        Url = new Uri("https://github.com/tommy-ph/Project-MovieWebAPIASPNETCore")
                    }
                });
                options.IncludeXmlComments(xmlPath);
            });

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