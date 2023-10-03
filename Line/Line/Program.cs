using Line.Models.DB;
using Line.Repositories;
using Line.Repositories.Interface;
using Line.Services;
using Line.Services.Interfaces;
using Microsoft.OpenApi.Models;
using Line.Loggers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.

service.AddControllers()
       .AddBsonSerializer();
service.AddScoped<IWebhookService, WebhookService>();
service.AddScoped<IWebhookRepository, WebhookRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ada's Line webhook API", Version = "v1" });

    //api 說明文件
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

service.AddHttpContextCatcher(opt =>
{
    opt.SetCatcher<LogCatcher>();
});

//mongoDB
var connString = "mongodb+srv://moimoi870416:0416@linecluster.fzqut86.mongodb.net/?retryWrites=true&w=majority";
service.AddMongoContext(new LineMongoDBContext(connString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ada's Line Webhook API V1");
});

app.UseHttpContextCatcher();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
