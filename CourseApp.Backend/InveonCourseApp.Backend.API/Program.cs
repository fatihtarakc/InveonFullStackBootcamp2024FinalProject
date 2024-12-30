var builder = WebApplication.CreateBuilder(args);
builder.AddApiLoggingWebApplicationBuilder();

// Add services to the container.
builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddDataAccessConcreteServices(builder.Configuration);
builder.Services.AddCacheServices(builder.Configuration);
builder.Services.AddBusinessConcreteServices(builder.Configuration);
//builder.Services.AddQueueServices(builder.Configuration);
builder.Services.AddBackgroundJobsServices(builder.Configuration);
builder.Services.AddApiServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddBackgroundJobsUseHangfireDashboardWithPathApplicationBuilder("/hangfire");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
