using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using HospitalDataBase.Core.Database;
using HospitalDataBase.Contracts;
using HospitalDataBase.Repository;
using HospitalDataBase.DataObjects.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalDataBaseApi", Version = "v1" }));
builder.Services.AddControllers();

builder.Services.AddScoped<IAnalysationTestRepository, AnalysationTestRepository>();
builder.Services.AddScoped<IDeviceServiceRepository, DeviceServiceRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IGoodsImportationRepository, GoodsImportationRepository>();
builder.Services.AddScoped<IHistoryMedicalExamRepository, HistoryMedicalExamRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:7094")
              .AllowCredentials();
    });
});

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalDataBase v1"));

app.UseHttpsRedirection();

app.UseCors("ClientPermission");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();