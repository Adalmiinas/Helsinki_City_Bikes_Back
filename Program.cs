using System;
using HelsinkiBikes.Import;
using Microsoft.Data.SqlClient;

namespace HelsinkiBikes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            var importData = new ImportData() { ConnectionString = GetConnectionString() };
            //importData.seeding("data/2021-05.csv");
            //importData.seeding("data/2021-06.csv");
            //importData.seeding("data/2021-07.csv");

            static string GetConnectionString()
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";
                builder.UserID = "SA";
                builder.Password = "Password123";
                builder.InitialCatalog = "HelsinkiBikes";
                builder.IntegratedSecurity = false;

                return builder.ConnectionString;
            }
        }
    }
}
