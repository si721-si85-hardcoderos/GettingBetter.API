//using GettingBetter.API.Advertisement_System.Domain.Repositories;
//using GettingBetter.API.Advertisement_System.Domain.Services;
//using GettingBetter.API.Advertisement_System.Persistence.Repositories;
//using GettingBetter.API.Advertisement_System.Services;

using GettingBetter.API.Advertisement_System.Domain.Repositories;
using GettingBetter.API.Advertisement_System.Domain.Services;
using GettingBetter.API.Advertisement_System.Persistence.Repositories;
using GettingBetter.API.Advertisement_System.Services;
using GettingBetter.API.Advisory_System.Domain.Repositories;
using GettingBetter.API.Advisory_System.Domain.Services;
using GettingBetter.API.Advisory_System.Persistence.Repositories;
using GettingBetter.API.Advisory_System.Services;
using GettingBetter.API.Event_System.Domain.Repositories;
using GettingBetter.API.Event_System.Domain.Services;
using GettingBetter.API.Event_System.Persistence.Repositories;
using GettingBetter.API.Event_System.Services;
//using GettingBetter.API.Event_System.Domain.Repositories;
//using GettingBetter.API.Event_System.Domain.Services;
//using GettingBetter.API.Event_System.Persistence.Repositories;
//using GettingBetter.API.Event_System.Services;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Persistence.Repositories;
using GettingBetter.API.GettingBetter_System.Services;
using GettingBetter.API.Learning_System.Domain.Repositories;
using GettingBetter.API.Learning_System.Domain.Services;
using GettingBetter.API.Learning_System.Persistence.Repositories;
using GettingBetter.API.Learning_System.Services;
//using GettingBetter.API.Learning_System.Services;
using GettingBetter.API.Shared.Domain.Repositories;
using GettingBetter.API.Shared.Mapping;
using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using GettingBetter.API.Tournament_System.Domain.Repositories;
using GettingBetter.API.Tournament_System.Domain.Services;
using GettingBetter.API.Tournament_System.Persistence.Repositories;
using GettingBetter.API.Tournament_System.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
     // Add API Documentation Information
     options.SwaggerDoc("v1", new OpenApiInfo
     {
         Version = "v1",
         Title = "Getting Better API",
         Description = "Getting Better RESTful API",
         TermsOfService = new Uri("https://acme-learning.com/tos"),
         Contact = new OpenApiContact
         {
             Name = "GettingBetter.studio",
             Url = new Uri("https://acme.studio")
         },
         License = new OpenApiLicense
         {
             Name = "Getting Better Resources License",
             Url = new Uri("https://acme-learning.com/license")
         }
     });
     options.EnableAnnotations();
    });

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
var _MyCors = "MyCors";
builder.Services.AddCors(options =>

{
    options.AddPolicy(name: _MyCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); ;
    });
});



builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICoachService, CoachService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ICyberRepository, CyberRepository>();
builder.Services.AddScoped<ICyberService, CyberService>();

builder.Services.AddScoped<IEventService, EventService>(); 
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddScoped<ILearningRepository, LearningRepository>();
builder.Services.AddScoped<ILearningService,LearningService>();

builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();

builder.Services.AddScoped<IAdvisoryRepository, AdvisoryRepository>();
builder.Services.AddScoped<IAdvisoryService, AdvisoryService>();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ITournamentService, TournamentService>();

builder.Services.AddScoped<IRegisterTournamentRepository, RegisterTournamentRepository>();
builder.Services.AddScoped<IRegisterTournamentService, RegisterTournamentService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsProduction())
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
         options.SwaggerEndpoint("v1/swagger.json", "v1");
         options.RoutePrefix = "swagger";
        });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(_MyCors);

app.Run();