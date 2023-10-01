using Line.Models;
using Line.Repositories;
using Line.Repositories.Interface;
using Line.Services;
using Line.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.

service.AddControllers();
service.AddScoped<IWebhookService, WebhookService>();
service.AddScoped<IWebhookRepository, WebhookRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ada's Line webhook API", Version = "v1" });
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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
