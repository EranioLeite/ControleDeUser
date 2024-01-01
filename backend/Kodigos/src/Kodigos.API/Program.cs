
using Serilog;
using Microsoft.EntityFrameworkCore;
using Kodigos.Infra.Data.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
    );
builder.Configuration.AddJsonFile("serilog.json", true, true);
builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog((ctx, lc) => lc
       .WriteTo.Console()
       .ReadFrom.Configuration(ctx.Configuration));


ConfigurationManager Configuration = builder.Configuration;

string ConnectionString = Configuration.GetConnectionString("DefaultConnection");

Log.Information("Init SQL Server Connection");
builder.Services.AddDbContext<KodigosContext>(options =>
    options.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("Kodigos.API")).EnableSensitiveDataLogging());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders().SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
    });
});

var app = builder.Build();

Log.Information("Executing Migraitions Database");

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<KodigosContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

Log.Information("Builder FInish!");