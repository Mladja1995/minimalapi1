using Diligent.MinimalAPI.Auth;
using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Endpoints;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FacultyContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// End points
builder.Services.AddStudentEndpoints();
builder.Services.AddProfesorEndpoints();
builder.Services.AddBookEndpoints();
builder.Services.AddProjectEndpoints();
builder.Services.AddCourseEndpoints();
builder.Services.AddClassroomEndpoints();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddAuthentication(ApiKeySchemeConstants.SchemeName)
    .AddScheme<ApiKeyAuthSchemeOptions, ApiKeyAuthHandler>(ApiKeySchemeConstants.SchemeName, _ => { });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.UseStudentEndpoints();
app.UseProfesorEndpoints();
app.UseBookEndpoints();
app.UseProjectEndpoints();
app.UseCourseEndpoints();
app.UseClassroomEndpoints();

app.Run();
