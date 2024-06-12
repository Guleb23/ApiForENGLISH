
using ApiForENGLISH.ChatHub;
using ApiForENGLISH.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace ApiForENGLISH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IDictionary<string, UserConnection>>(opts => new Dictionary<string, UserConnection>());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseNpgsql("Server=147.45.108.218;Port=5432;Database=default_db;User Id=gen_user;Password=qhBErM:1H?OsD+;");
            });

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseCors(options =>
            {
                options.WithOrigins("http://89.223.69.75").
                AllowAnyHeader().
                AllowCredentials().
                AllowAnyMethod();
            });
            app.MapHub<ChatHub.ChatHub>("/chat");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images")),
                RequestPath = "/Image"
            }) ;

            
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

