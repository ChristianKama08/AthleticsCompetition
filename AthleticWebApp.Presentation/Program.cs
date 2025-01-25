using AthleticWebApp.BusinessLogic.Profiles.MappingConfigurations;
using AthleticWebApp.BusinessLogic.Services.Implementations;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Repositories.Implementations;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AthleteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AthleteConnection"))
    );

builder.Services.AddScoped<IAthleteRepository, AthleteRepository>();
builder.Services.AddScoped<IAthleteService, AthleteService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IResultServices, ResultService>();

builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();

builder.Services.AddAutoMapper(typeof(ApplicationConfiguration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
