using Dadata_API.MappingProfiles;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DadataProfile));
var app = builder.Build();


NLog.LogManager.Setup().LoadConfiguration(builder => {
    builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToFile(fileName: "C:\\Users\\Admin\\Desktop\\Dadadata_API_${shortdate}.txt");
    builder.ForLogger().FilterMinLevel(NLog.LogLevel.Warn).WriteToFile(fileName: "C:\\Users\\Admin\\Desktop\\Dadadata_API_${shortdate}.txt");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
