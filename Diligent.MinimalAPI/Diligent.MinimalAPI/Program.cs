using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Endpoints;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FacultyContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// End points
builder.Services.AddStudentEndpoints();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseStudentEndpoints();

app.Run();
