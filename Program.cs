using System;
using HelsinkiBikes.Import;
using Microsoft.Data.SqlClient;
using HelsinkiBikes.Repository;
using Microsoft.AspNetCore.Builder;
using NuGet.Protocol.Core.Types;
using HelsinkiBikes.Controllers;

namespace HelsinkiBikes
{
    public class Program

    {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<IStationRepository, StationRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(AppDomain));


            var app = builder.Build();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();


            //Importing the data to the database
            var importTrips = new ImportTrips();
            var importStations = new ImportStations();

            importStations.seeding("data/Helsingin_ja_Espoon_kaupunkipy%C3%B6r%C3%A4asemat_avoin.csv");

            importTrips.seeding("data/2021-05.csv");
            importTrips.seeding("data/2021-06.csv");
            importTrips.seeding("data/2021-07.csv");

        }
    }
}
