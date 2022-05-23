using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FacultyContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// End points
builder.Services.AddStudentEndpoints();
builder.Services.AddProfesorEndpoints();
builder.Services.AddBookEndpoints();
builder.Services.AddProjectEndpoints();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseStudentEndpoints();
app.UseProfesorEndpoints();
app.UseBookEndpoints();
app.UseProjectEndpoints();
app.Run();
