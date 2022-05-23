using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FacultyContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// End points
builder.Services.AddStudentEndpoints();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseStudentEndpoints();
app.Run();
