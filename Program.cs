using AuditLoggerPoc;
using Serilog;


try
{ 
    Console.Out.Flush();
    var builder = WebApplication.CreateBuilder(args);

     var loggerConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    using var log = new LoggerConfiguration().ReadFrom.Configuration(loggerConfiguration)
                        .CreateLogger();
    Log.Logger = log;

    log.Information("Sample information message");

    // Add services to the container.

    builder.Services.AddScoped<IUserService, UserService>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog(log);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        Log.Information("Starting up the WEB API");
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseSerilogRequestLogging();
        Log.Fatal("Sample error just for fun");
    }
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    Log.Information("Starting up the WEB API");
   
}
catch (Exception)
{
    Log.Fatal("Application not running");
    throw;
}
finally 
{
    Log.CloseAndFlush();
}

