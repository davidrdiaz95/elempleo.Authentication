using elempleo.Authentication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.ConfigureDataBaseConnection(connectionString);
builder.Services.ConfigureCors();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureMapSectionConfiguration(builder.Configuration);
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

app.UseCors("MyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
