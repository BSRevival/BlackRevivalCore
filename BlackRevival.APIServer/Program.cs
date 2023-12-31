using BlackRevival.APIServer.Classes;
using BlackRevival.APIServer.Database;
using BlackRevival.APIServer.Server;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddSingleton<SessionManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

//app.UseHttpsRedirection();
app.UseSessionMiddleware();

app.UseAuthorization();
TableManager.Init();

app.MapControllers();
MasterServer.StartAsync();
Console.WriteLine("Master Server is running. Press any key to stop.");

app.Run();
MasterServer.Stop();
