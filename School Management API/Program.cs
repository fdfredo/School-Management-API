using Microsoft.EntityFrameworkCore;
using School_Management_API.Data;
using School_Management_API.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.
	Configuration.GetConnectionString("DefaultConnectionString")));

//Service Configuration
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IStaffsService, StaffsService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ITimeTablesService, TimeTablesService>();
builder.Services.AddScoped<IAdministrationsService, AdministrationsService>();
builder.Services.AddScoped<IAdmissionsService, AdmissionsService>();
builder.Services.AddScoped<ICurriculumsService, CurriculumsService>();
builder.Services.AddScoped<IExamsService, ExamsService>();
builder.Services.AddScoped<IFacultiesService, FacultiesService>();
builder.Services.AddScoped<IResultsService, ResultsService>();



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
