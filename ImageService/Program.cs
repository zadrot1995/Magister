using Microsoft.AspNetCore.Http.Features;

namespace ImageService
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

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 209715200; // Set the limit to 200 MB or any value that suits your needs
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 209715200; // Set the limit to 200 MB or any value that suits your needs
            });

            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            builder.Services.AddMvc();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles(); // Enable serving static files
            app.UseCors("AllowAnyOrigin");


            app.MapControllers();

            app.Run();
        }
    }
}